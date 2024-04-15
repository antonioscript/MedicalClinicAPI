#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/src/api
COPY ["MedicalClinic.WebApi/MedicalClinic.WebApi.csproj", "MedicalClinic.WebApi/"]
COPY ["MedicalClinic.Infrastructure.DocumentProcessor/MedicalClinic.Infrastructure.DocumentProcessor.csproj", "MedicalClinic.Infrastructure.DocumentProcessor/"]
COPY ["MedicalClinic.Application/MedicalClinic.Application.csproj", "MedicalClinic.Application/"]
COPY ["MedicalClinic.Domain/MedicalClinic.Domain.csproj", "MedicalClinic.Domain/"]
COPY ["MedicalClinic.Infrastructure.Shared.Results/MedicalClinic.Infrastructure.Shared.Results.csproj", "MedicalClinic.Infrastructure.Shared.Results/"]
COPY ["MedicalClinic.Resource/MedicalClinic.Resource.csproj", "MedicalClinic.Resource/"]
COPY ["MedicalClinic.Infrastructure/MedicalClinic.Infrastructure.csproj", "MedicalClinic.Infrastructure/"]
RUN dotnet restore "./MedicalClinic.WebApi/MedicalClinic.WebApi.csproj"
COPY . .
WORKDIR "/src/src/api/MedicalClinic.WebApi"
RUN dotnet build "./MedicalClinic.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MedicalClinic.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedicalClinic.WebApi.dll"]