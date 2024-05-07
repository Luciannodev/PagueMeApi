# Use the .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY src /App


# Restore as distinct layers
RUN dotnet restore ./PagueMeApi.sln

# Build and publish a release
RUN dotnet publish -c Release -o out

ENV ASPNETCORE_ENVIRONMENT=Development
ENV SECRET_KEY=1234567890
ENV ClientSettings__Database__Server="host.docker.internal"
ENV ClientSettings__Database__Name="paguemedb"
ENV ClientSettings__Database__User="root"
ENV ClientSettings__Database__Password="lembrei12"
ENV ClientSettings__Database__Port=3306
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

ENTRYPOINT ["dotnet", "out/PagueMe.Api.dll"]