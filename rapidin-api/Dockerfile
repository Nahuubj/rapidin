# Usa la imagen oficial de .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["rapidin-api/rapidin-api.csproj", "rapidin-api/"]
RUN dotnet restore "rapidin-api/rapidin-api.csproj"

COPY . .
WORKDIR "/src/rapidin-api"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rapidin-api.dll"]
