data "aws_ami" "ubuntu" {
  most_recent = true
  filter {
    name   = "name"
    values = ["ubuntu/images/hvm-ssd/ubuntu-focal-20.04-amd64-server-*"]
  }
  filter {
    name   = "virtualization-type"
    values = ["hvm"]
  }
  owners = ["099720109477"] # Canonical
}


resource "aws_instance" "dotnet_server" {
  ami           = data.aws_ami.ubuntu.id
  instance_type = var.instance_type
  key_name      = aws_key_pair.deployer.key_name
  vpc_security_group_ids = [aws_security_group.maingroup.id]
  iam_instance_profile   = aws_iam_instance_profile.ec2-profile.name
  connection {
    type        = "ssh"
    host        = self.public_ip
    user        = "ubuntu"
    private_key = var.private_key
    timeout     = "4m"
  }
  tags = {
    Name        = var.name
    Environment = var.Environment
    Provisioner = "Terraform"
    Repo        = var.repo
  }
  
}

resource "aws_iam_instance_profile" "ec2-profile" {
  name = "ec2-profile"
  role = "ECR-LOGIN-AUTO"
}

resource "aws_security_group" "maingroup" {
  egress = [
    {
      cidr_blocks      = ["0.0.0.0/0"]
      description      = ""
      from_port        = 0
      ipv6_cidr_blocks = []
      prefix_list_ids  = []
      protocol         = "-1"
      security_groups  = []
      self             = false
      to_port          = 0
    }
  ]
  ingress = [
    {
      cidr_blocks      = ["0.0.0.0/0", ]
      description      = ""
      from_port        = 22
      ipv6_cidr_blocks = []
      prefix_list_ids  = []
      protocol         = "tcp"
      security_groups  = []
      self             = false
      to_port          = 22
    },
    {
      cidr_blocks      = ["0.0.0.0/0", ]
      description      = ""
      from_port        = 80
      ipv6_cidr_blocks = []
      prefix_list_ids  = []
      protocol         = "tcp"
      security_groups  = []
      self             = false
      to_port          = 80
    }
  ]
}

resource "aws_key_pair" "deployer" {
  key_name   = var.key_name
  public_key = var.public_key
}

output "instance_public_ip" {
  value     = aws_instance.dotnet_server.public_ip
  sensitive = true
}

























# resource "tls_private_key" "example" {
#   algorithm = "RSA"
#   rsa_bits  = 4096
# }

# resource "aws_key_pair" "deployer" {
#   key_name   = "deployer-key"
#   public_key = tls_private_key.example.public_key_openssh
# }


# resource "aws_security_group" "allow_mysql" {
#   name        = "allow_mysql"
#   description = "Allow mysql inbound traffic"

#   ingress {
#     from_port   = 3306
#     to_port     = 3306
#     protocol    = "tcp"
#     cidr_blocks = ["0.0.0.0/0"]
#   }

#   egress {
#     from_port   = 0
#     to_port     = 0
#     protocol    = "-1"
#     cidr_blocks = ["0.0.0.0/0"]
#   }
# }

# resource "aws_db_instance" "paguemedb" {
#   allocated_storage    = 20
#   storage_type         = "gp2"
#   engine               = "mysql"
#   instance_class       = "db.t3.micro"
#   db_name              = var.db_name
#   username             = var.username
#   password             = var.password
#   publicly_accessible  = true
#   skip_final_snapshot  = true
#   backup_retention_period = 0 
#   vpc_security_group_ids = [aws_security_group.allow_mysql.id]
# }

# resource "time_sleep" "wait" {
#   depends_on = [aws_db_instance.paguemedb]

#   create_duration = "10s"
# }

# resource "null_resource" "db_setup" {
#   depends_on = [time_sleep.wait]

#   provisioner "local-exec" {
#     command = "mysql -v -h ${aws_db_instance.paguemedb.address} -u ${var.username} -p${var.password} ${var.db_name} < ./SQL/Initial.sql"
#   }
#   triggers = {
#     db_instance_address = aws_db_instance.paguemedb.address
#   }
# }

# resource "aws_ecr_repository" "repository" {
#   name = "my-ecr-repo"
# }



# resource "aws_s3_bucket" "bucket" {
#   bucket = "my-pem-bucket"
#   acl    = "private"

#   versioning {
#     enabled = true
#   }
# }

# resource "aws_s3_bucket_object" "object" {
#   bucket = aws_s3_bucket.bucket.id
#   key    = "private_key.pem"
#   content = tls_private_key.example.private_key_pem
#   acl    = "private"
# }
