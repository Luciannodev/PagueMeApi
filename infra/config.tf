terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
  }
    backend "s3" {
    key = "aws/ec2-deploy/terraform.tfstate"
  }
}


provider "aws" {
  region = var.region
}

