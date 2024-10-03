variable "master_username" {
  description = "The master username for the RDS cluster"
  type        = string
  sensitive   = true
}

variable "master_password" {
  description = "The master password for the RDS cluster"
  type        = string
  sensitive   = true
}

variable "api_gateway_type" {
  description = "Type of API Gateway (REGIONAL or EDGE)"
  type        = string
  default     = "REGIONAL"
}

variable "aws_region" {
  description = "The AWS region to deploy the resources"
  type        = string
  default     = "us-east-1"
  
}