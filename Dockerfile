# Use the .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY src /App


# Restore as distinct layers
RUN dotnet restore ./PagueMeApi.sln

# Build and publish a release
RUN dotnet publish -c Release -o out

ARG SECRET_KEY
ARG DB_HOST
ARG NAME
ARG USER
ARG PASSWORD
ARG PORT



ENV ClientSettings__Database__Server=${DB_HOST}
ENV ClientSettings__Database__Name=${NAME}
ENV ClientSettings__Database__User=${USER}
ENV ClientSettings__Database__Password=${PASSWORD}
ENV ClientSettings__Database__Port=${PORT}
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

ENTRYPOINT ["dotnet", "out/PagueMe.Api.dll"]