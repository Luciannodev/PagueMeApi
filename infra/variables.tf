variable "region" {
  description = "The AWS region to deploy resources."
  default     = "ap-south-1"
}

variable "name" {
  description = "name of the application"
  default     = "myapp"
}


variable "instance_type" {
  description = "The type of instance that define configurations of the machine."
  default     = "t4g.nano" # "t2.micro" "t2.small" "t2.medium" "t2.large" "t2.xlarge" "t2.2xlarge" "m3.medium" "m3.large" "m3.xlarge" "m3.2xlarge" "m4.large" "m4.xlarge" "m4.2xlarge" "m4.4xlarge" "m4.10xlarge" "m4.16xlarge" "m5.large" "m5.xlarge" "m5.2xlarge" "m5.4xlarge" "m5.12xlarge" "m5.24xlarge" "m5a.large" "m5a.xlarge" "m5a.2xlarge" "m5a.4xlarge" "m5a.12xlarge" "m5a.24xlarge" "m5ad.large" "m5ad.xlarge" "m5ad.2xlarge" "m5ad.4xlarge" "m5ad.12xlarge" "m5ad.24xlarge" "m5d.large" "m5d.xlarge" "m5d.2xlarge" "m5d.4xlarge" "m5d.12xlarge" "m5d.24xlarge" "m5dn.large" "m5dn.xlarge" "m5dn.2xlarge" "m5dn.4xlarge" "m5dn.12xlarge" "m5dn.24xlarge" "m5n.large" "m5n.xlarge" "m5n.2xlarge" "m5n.4xlarge" "m5n.12xlarge" "m5n.24xlarge" "m6g.medium" "m6g.large" "m6g.xlarge" "m6g.2xlarge" "m6g.4xlarge" "m6g.8xlarge" "m6g.12xlarge" "m6g.16xlarge" "m6gd.medium" "m6gd.large" "m6gd.xlarge" "m6gd.2xlarge" "m6gd.4xlarge" "m6gd.8x

}

variable "Environment" {
  description = "The environment of the application."
  default     = "dev"
}

variable "repo" {
  description = "repository of the application"
  default     = "https://github.com/Luciannodev/PagueMeApi"
}

variable "IMAGE_TAG" {
  description = "The tag of the image to deploy."
  default     = "latest"
  
}

variable "db_name" {
  default = "paguemedb"
}

variable "username" {
  default = "root"
}

variable "password" {
  default = "lembrei12"
}

variable "public_key" {
  
}
variable "private_key" {
  
}
variable "key_name" {
  
}
variable "bucket" {
  
}