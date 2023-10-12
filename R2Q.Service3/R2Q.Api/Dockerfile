#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["R2Q.Api/R2Q.Service3.Api.csproj", "R2Q.Api/"]
COPY ["R2Q.Application/R2Q.Application.csproj", "R2Q.Application/"]
COPY ["R2Q.Domain/R2Q.Domain.csproj", "R2Q.Domain/"]
COPY ["R2Q.Infrastructure/R2Q.Infrastructure.csproj", "R2Q.Infrastructure/"]
RUN dotnet restore "R2Q.Api/R2Q.Service3.Api.csproj"
COPY . .
WORKDIR "/src/R2Q.Api"
RUN dotnet build "R2Q.Service3.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "R2Q.Service3.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "R2Q.Service3.Api.dll"]