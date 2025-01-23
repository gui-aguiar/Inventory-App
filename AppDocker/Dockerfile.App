# AppDocker/Dockerfile.App

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de solução e os projetos
COPY VelozientApp.sln ./
COPY InventoryTracker.Contracts/InventoryTracker.Contracts.csproj InventoryTracker.Contracts/
COPY InventoryTracker.DependencyInjection/InventoryTracker.DependencyInjection.csproj InventoryTracker.DependencyInjection/
COPY InventoryTracker.Dtos/InventoryTracker.Dtos.csproj InventoryTracker.Dtos/
COPY InventoryTracker.Models/InventoryTracker.Models.csproj InventoryTracker.Models/
COPY InventoryTracker.Repositories/InventoryTracker.Repositories.csproj InventoryTracker.Repositories/
COPY InventoryTracker.Services/InventoryTracker.Services.csproj InventoryTracker.Services/
COPY InventoryTracker.Database/InventoryTracker.Database.csproj InventoryTracker.Database/
COPY InventoryTracker.Server/InventoryTracker.Server.csproj InventoryTracker.Server/

# Restaura as dependências
RUN dotnet restore

# Copia o restante dos arquivos e publica o aplicativo
COPY . .
WORKDIR /src/InventoryTracker.Server
RUN dotnet publish -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "InventoryTracker.Server.dll"]
