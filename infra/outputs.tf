output "public_ip" {
  value = aws_instance.myapp.public_ip
}
output "rds_endpoint" {
  value = aws_db_instance.paguemedb.endpoint
}

output "db_name" {
  value = aws_db_instance.paguemedb.db_name
    sensitive = true
}

output "db_user" {
 value = aws_db_instance.paguemedb.username
    sensitive = true
}

output "db_password" {
 value = aws_db_instance.paguemedb.password
 sensitive = true
}

output "db_port" {
 value = aws_db_instance.paguemedb.port
}