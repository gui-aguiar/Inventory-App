FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Porta exposta
EXPOSE 5000
EXPOSE 5001

# Comando de inicialização
ENTRYPOINT ["dotnet", "InventoryTracker.API.dll"]
