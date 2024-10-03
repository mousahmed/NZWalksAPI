
terraform {
  required_version = ">= 1.8.0"

  backend "s3" {
    bucket         = "terraformstatebucket-moustafa"    # Replace with your actual bucket name
    key            = "terraform/state.tfstate"          # Path in the bucket where the state file will be stored
    region         = "us-east-1"                        # Change to the appropriate region
    encrypt        = true                               # Encrypt the state file
    
  }

  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.69" # Specify the AWS provider version you want to use
    }
  }
}

provider "aws" {
  region = "us-east-1" # Change to your preferred region
}

