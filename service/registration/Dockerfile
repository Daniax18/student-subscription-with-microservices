# Image SDK pour build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copier uniquement le csproj pour le restore
COPY registration.csproj ./
RUN dotnet restore

# Copier le reste
COPY . .

# Publish
RUN dotnet publish -c Release -o /app/out

# Image runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "registration.dll"]
