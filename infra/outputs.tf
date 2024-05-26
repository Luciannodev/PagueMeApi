output "server_public_ip" {
  value = aws_instance.dotnet_server.public_ip
}
# output "rds_endpoint" {
#   value = aws_db_instance.paguemedb.endpoint
# }

# output "db_name" {
#   value = aws_db_instance.paguemedb.db_name

# }

# output "db_user" {
#  value = aws_db_instance.paguemedb.username
#     sensitive = true
# }

# output "db_password" {
#  value = aws_db_instance.paguemedb.password
#  sensitive = true
# }

# output "db_port" {
#  value = aws_db_instance.paguemedb.port
# }

output "ecr_repository_url" {
  value = aws_ecr_repository.repository.repository_url 
}
# output "db_host" {
#   value = aws_db_instance.paguemedb.address
# }

output "instance_id" {
  value = aws_instance.dotnet_server.id
  }

# output "private_key_pem" {
#   description = "Private key in PEM format"
#   value       = tls_private_key.example.private_key_pem
#   sensitive   = true
# }

