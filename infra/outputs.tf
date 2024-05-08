output "public_ip" {
  value = aws_instance.myapp.public_ip
}
output "rds_endpoint" {
  value = aws_db_instance.paguemedb.endpoint
}