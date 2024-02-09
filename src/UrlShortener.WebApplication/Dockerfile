FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/UrlShortener.WebApplication/UrlShortener.WebApplication.csproj", "src/UrlShortener.WebApplication/"]
COPY ["src/UrlShortener.Domain/UrlShortener.Domain.csproj", "src/UrlShortener.Domain/"]
COPY ["src/UrlShortener.Data/UrlShortener.Data.csproj", "src/UrlShortener.Data/"]
RUN dotnet restore "./src/UrlShortener.WebApplication/./UrlShortener.WebApplication.csproj"
COPY . .
WORKDIR "/src/src/UrlShortener.WebApplication"
RUN dotnet build "./UrlShortener.WebApplication.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UrlShortener.WebApplication.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UrlShortener.WebApplication.dll"]