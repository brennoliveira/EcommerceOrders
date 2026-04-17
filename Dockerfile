FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY . .

RUN dotnet restore

# PUBLICAR APENAS A API (evita warning)
RUN dotnet publish Api/Api.csproj -c Release -o out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Api.dll"]