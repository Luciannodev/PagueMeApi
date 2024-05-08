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

resource "aws_security_group" "allow_mysql" {
  name        = "allow_mysql"
  description = "Allow mysql inbound traffic"

  ingress {
    from_port   = 3306
    to_port     = 3306
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

resource "aws_db_instance" "paguemedb" {
  allocated_storage    = 20
  storage_type         = "gp2"
  engine               = "mysql"
  instance_class       = "db.t3.micro"
  db_name              = var.db_name
  username             = var.username
  password             = var.password
  publicly_accessible  = true
  skip_final_snapshot  = true
  backup_retention_period = 0 
  vpc_security_group_ids = [aws_security_group.allow_mysql.id]
}

resource "time_sleep" "wait" {
  depends_on = [aws_db_instance.paguemedb]

  create_duration = "10s"
}

resource "null_resource" "db_setup" {
  depends_on = [time_sleep.wait]

  provisioner "local-exec" {
    command = "mysql -v -h ${aws_db_instance.paguemedb.address} -u ${var.username} -p${var.password} ${var.db_name} < ./SQL/Initial.sql"
  }
  triggers = {
    db_instance_address = aws_db_instance.paguemedb.address
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