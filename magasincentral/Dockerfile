# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY magasincentral/magasincentral.csproj ./magasincentral/
RUN dotnet restore ./magasincentral/magasincentral.csproj

# Copy all and publish
COPY . ./
WORKDIR /src/magasincentral
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "magasincentral.dll", "--urls", "http://0.0.0.0:80"]