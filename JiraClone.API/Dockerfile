##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 5000
#EXPOSE 5001
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["JiraClone.API/JiraClone.API.csproj", "JiraClone.API/"]
#COPY ["JiraClone.Application/JiraClone.Application.csproj", "JiraClone.Application/"]
#COPY ["JiraClone.Domain/JiraClone.Domain.csproj", "JiraClone.Domain/"]
#COPY ["JiraClone.Infrastructure/JiraClone.Infrastructure.csproj", "JiraClone.Infrastructure/"]
#
#RUN dotnet restore "./JiraClone.API/./JiraClone.API.csproj"
#COPY . .
#WORKDIR "/src/JiraClone.API"
#RUN dotnet build "./JiraClone.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./JiraClone.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "JiraClone.API.dll"]



# Use the .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["JiraClone.API/JiraClone.API.csproj", "JiraClone.API/"]
COPY ["JiraClone.Application/JiraClone.Application.csproj", "JiraClone.Application/"]
COPY ["JiraClone.Domain/JiraClone.Domain.csproj", "JiraClone.Domain/"]
COPY ["JiraClone.Infrastructure/JiraClone.Infrastructure.csproj", "JiraClone.Infrastructure/"]

RUN dotnet restore "./JiraClone.API/JiraClone.API.csproj"
COPY . .
WORKDIR "/src/JiraClone.API"
RUN dotnet build "JiraClone.API.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./JiraClone.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JiraClone.API.dll"]