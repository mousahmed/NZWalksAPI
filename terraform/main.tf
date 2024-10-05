
# IAM Role for Lambda
resource "aws_iam_role" "lambda_exec" {
  name = "lambda_exec_role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17",
    Statement = [{
      Action = "sts:AssumeRole",
      Effect = "Allow",
      Principal = {
        Service = "lambda.amazonaws.com"
      }
    }]
  })
}

# IAM Policy for Lambda execution
resource "aws_iam_role_policy" "lambda_exec_policy" {
  role   = aws_iam_role.lambda_exec.id
  policy = jsonencode({
    Version = "2012-10-17",
    Statement = [
      {
        Action = [
          "logs:*",
          "s3:*",
          "rds:*"
        ],
        Effect   = "Allow",
        Resource = "*"
      }
    ]
  })
}
# 1. Lambda Function
resource "aws_lambda_function" "dotnet_lambda" {
  function_name = "dotnet-walks-api"
  role          = aws_iam_role.lambda_exec.arn
  handler       = "NZWalksAPI"
  runtime       = "dotnet8"
  timeout       = 15
  s3_bucket = "ncs-deployments"
  s3_key    = "lambda/dotnet-api.zip" # Upload your zipped deployment here

  environment {
    variables = {
      DB_CONNECTION_STRING = aws_rds_cluster.aurora.endpoint
    }
  }
}


# 2. Aurora Serverless DB
resource "aws_rds_cluster" "aurora" {
  cluster_identifier = "dotnet-aurora-cluster"
  engine             = "aurora-postgresql" # or "aurora-mysql" if you prefer MySQL
  engine_mode        = "serverless"
  scaling_configuration {
    auto_pause   = true
    min_capacity = 2
    max_capacity = 2
    seconds_until_auto_pause = 300
  }

  database_name = "dotnetwalksdb"
  master_username = var.master_username
  master_password = var.master_password
  skip_final_snapshot = true
}

# 3. API Gateway
resource "aws_api_gateway_rest_api" "dotnet_api_gateway" {
  name        = "DotNet Walks API"
  description = "API Gateway for .NET Walks Lambda"
  
  endpoint_configuration {
    types = ["REGIONAL"]  # Change to Regional
  }
}

resource "aws_api_gateway_resource" "root" {
  rest_api_id = aws_api_gateway_rest_api.dotnet_api_gateway.id
  parent_id   = aws_api_gateway_rest_api.dotnet_api_gateway.root_resource_id
  path_part   = "{proxy+}"
}

resource "aws_api_gateway_method" "proxy_method" {
  rest_api_id   = aws_api_gateway_rest_api.dotnet_api_gateway.id
  resource_id   = aws_api_gateway_resource.root.id
  http_method   = "ANY"
  authorization = "NONE"
}

resource "aws_api_gateway_integration" "proxy_integration" {
  rest_api_id          = aws_api_gateway_rest_api.dotnet_api_gateway.id
  resource_id          = aws_api_gateway_resource.root.id
  http_method          = aws_api_gateway_method.proxy_method.http_method
  integration_http_method = "POST"
  type                 = "AWS_PROXY"
  uri                  = aws_lambda_function.dotnet_lambda.invoke_arn
}
resource "aws_api_gateway_domain_name" "dotnet_api_domain_name" {
  domain_name              = "dotnet-walks-api.nullcloudsolutions.com"
  regional_certificate_arn = aws_acm_certificate_validation.certificate_validation.certificate_arn
  security_policy          = "TLS_1_2"
  endpoint_configuration {
    types = ["REGIONAL"]
  }
}

# Base Path Mapping to link the custom domain and the API Gateway
resource "aws_api_gateway_base_path_mapping" "base_path_mapping" {
  domain_name = aws_api_gateway_domain_name.dotnet_api_domain_name.domain_name
  api_id = aws_api_gateway_rest_api.dotnet_api_gateway.id
  stage_name  = aws_api_gateway_deployment.api_deployment.stage_name
}

resource "aws_api_gateway_deployment" "api_deployment" {
  rest_api_id = aws_api_gateway_rest_api.dotnet_api_gateway.id
  stage_name  = "prod"
  depends_on = [aws_api_gateway_integration.proxy_integration]
}

# 5. Subdomain & SSL Certificate
data "aws_route53_zone" "main_zone" {
  name = "nullcloudsolutions.com"
  private_zone = false
}

resource "aws_route53_record" "api_subdomain" {
  zone_id = data.aws_route53_zone.main_zone.zone_id
  name    = "dotnet-walks-api.nullcloudsolutions.com"
  type    = "A"
  alias {
    name                   = aws_api_gateway_domain_name.dotnet_api_domain_name.regional_domain_name  # Use the regional domain name from the custom domain
    zone_id                = aws_api_gateway_domain_name.dotnet_api_domain_name.regional_zone_id       # Use the zone ID for the regional endpoint
    evaluate_target_health = false
  }
}

resource "aws_acm_certificate" "certificate" {
  domain_name       = "dotnet-walks-api.nullcloudsolutions.com"
  validation_method = "DNS"
  tags = {
    Name = "dotnet-walks-cert"
  }
}
resource "aws_acm_certificate_validation" "certificate_validation" {
  certificate_arn         = aws_acm_certificate.certificate.arn

  validation_record_fqdns = [
    for option in aws_acm_certificate.certificate.domain_validation_options : option.resource_record_name
  ]
}

resource "aws_route53_record" "certificate_validation" {
  for_each = {
    for dvo in aws_acm_certificate.certificate.domain_validation_options : dvo.domain_name => {
      name   = dvo.resource_record_name
      type   = dvo.resource_record_type
      value  = dvo.resource_record_value
    }
  }

  zone_id = data.aws_route53_zone.main_zone.zone_id
  name    = each.value.name
  type    = each.value.type
  records = [each.value.value]
  ttl     = 60
}


