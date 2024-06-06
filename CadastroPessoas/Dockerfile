# Use a imagem base do .NET 8.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar os arquivos do projeto e restaurar dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar o restante dos arquivos e construir a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CadastroPessoas.dll"]
