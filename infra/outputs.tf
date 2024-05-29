output "instance_public_ip" {
  value = aws_instance.dotnet_server.public_ip
  sensitive = true
}

