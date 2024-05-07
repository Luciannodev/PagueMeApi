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

resource "aws_db_instance" "default" {
  allocated_storage    = 20
  storage_type         = "gp2"
  engine               = "mysql"
  engine_version       = "8.0.28"
  instance_class       = "db.t4g.micro"
  username             = var.username
  password             = var.password
  publicly_accessible  = true
  skip_final_snapshot  = true
}

resource "null_resource" "db_setup" {
  provisioner "local-exec" {
    command = "mysql -h ${aws_db_instance.default.address} -u ${var.username} -p${var.password} ${var.db_name} < /path/to/infra/SQL/initial.sql"
  }
    triggers = {
    db_instance_address = aws_db_instance.default.address
  }
  }
  


resource "aws_ecr_repository" "repository" {
  name = "my-ecr-repo"
}

resource "aws_instance" "myapp" {
  ami           = data.aws_ami.ubuntu.id
  instance_type = var.instance_type
  user_data = <<-EOF
              #!/bin/bash
              sudo apt-get update
              sudo apt-get install -y docker.io
              sudo docker run -d -p 80:80 ${aws_ecr_repository.repository.repository_url}:${var.IMAGE_TAG}
              EOF
  tags = {
    Name        = var.name
    Environment = var.Environment
    Provisioner = "Terraform"
    Repo        = var.repo
  }
}