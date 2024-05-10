resource "github_actions_variable" "db_name" {
  repository       = "https://github.com/Luciannodev/PagueMeApi"
  variable_name    = "db_name"
  value            =  aws_db_instance.paguemedb.username
  depends_on = [ aws_db_instance.paguemedb ]
}

resource "github_actions_variable" "db_user" {
  repository       = "https://github.com/Luciannodev/PagueMeApi"
    variable_name    = "db_user"
    value            = aws_db_instance.paguemedb.username
      depends_on = [ aws_db_instance.paguemedb ]
}

resource "github_actions_variable" "db_password" {
  repository       = "https://github.com/Luciannodev/PagueMeApi"
    variable_name    = "db_password"
    value            = aws_db_instance.paguemedb.password
      depends_on = [ aws_db_instance.paguemedb ]
}

resource "github_actions_variable" "db_port" {
  repository       = "https://github.com/Luciannodev/PagueMeApi"
    variable_name    = "db_port"
    value            = aws_db_instance.paguemedb.port
      depends_on = [ aws_db_instance.paguemedb ]
}

resource "github_actions_variable" "ecr_registry" {
    repository       = "https://github.com/Luciannodev/PagueMeApi"
    variable_name    = "ecr_registry"
    value            = aws_ecr_repository.repository.repository_url
    depends_on = [ aws_ecr_repository.repository ]
}

resource "github_actions_variable" "db_host" {
      repository       = "https://github.com/Luciannodev/PagueMeApi"
        variable_name    = "db_host"
        value            = aws_db_instance.paguemedb.address
          depends_on = [ aws_db_instance.paguemedb ]
}