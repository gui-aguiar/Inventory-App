# AppDocker/Dockerfile.App

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de solução e os projetos
COPY . ./

# Restaura as dependências
RUN dotnet restore "VelozientApp.sln"

# Copia o restante dos arquivos e publica o aplicativo
COPY . ./
RUN dotnet publish "VelozientApp.sln" -c Release -o /app

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENV APP_PORT=5019
EXPOSE ${APP_PORT}

ENV DB_PATH=/data/inventory.db
RUN mkdir -p /data

ENTRYPOINT ["dotnet", "InventoryTracker.Server.dll"]
