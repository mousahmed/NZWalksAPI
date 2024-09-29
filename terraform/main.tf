provider "aws" {
  region = "us-east-1" # Change to your preferred region
}

# 1. Lambda Function
resource "aws_lambda_function" "dotnet_lambda" {
  function_name = "dotnet-walks-api"
  role          = aws_iam_role.lambda_exec.arn
  handler       = "LambdaEntryPoint::LambdaEntryPoint.Function::FunctionHandlerAsync" # Change to your handler
  runtime       = "dotnetcore8.0"
  timeout       = 15

  s3_bucket = aws_s3_bucket.lambda_deployments.bucket
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
    max_capacity = 8
    seconds_until_auto_pause = 300
  }

  database_name = "dotnetwalksdb"
  master_username = "admin"
  master_password = "YourPassword123"
}

resource "aws_rds_cluster_instance" "aurora_instance" {
  count              = 1
  identifier         = "aurora-instance-${count.index}"
  cluster_identifier = aws_rds_cluster.aurora.id
  instance_class     = "db.serverless"
}

# 3. API Gateway
resource "aws_api_gateway_rest_api" "dotnet_api_gateway" {
  name        = "DotNet Walks API"
  description = "API Gateway for .NET Walks Lambda"
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

resource "aws_api_gateway_deployment" "api_deployment" {
  rest_api_id = aws_api_gateway_rest_api.dotnet_api_gateway.id
  stage_name  = "prod"
}

# 4. S3 Bucket for static files and images
resource "aws_s3_bucket" "static_files" {
  bucket = "dotnet-walks-static"
  acl    = "public-read"

  website {
    index_document = "index.html"
    error_document = "error.html"
  }
}

# 5. Subdomain & SSL Certificate
resource "aws_route53_zone" "main_zone" {
  name = "nullcloudsolutions.com"
}

resource "aws_route53_record" "api_subdomain" {
  zone_id = aws_route53_zone.main_zone.zone_id
  name    = "dotnet-walks-api.nullcloudsolutions.com"
  type    = "A"
  alias {
    name                   = aws_api_gateway_rest_api.dotnet_api_gateway.execution_arn
    zone_id                = aws_api_gateway_rest_api.dotnet_api_gateway.execution_arn
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
  validation_record_fqdns = [aws_route53_record.api_subdomain.fqdn]
}

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
