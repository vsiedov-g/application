# ---------------------
# Build stage
# ---------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src



# Copy everything and restore dependencies
COPY . .
RUN apt-get update && \
    apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_20.x | bash - && \
    apt-get install -y nodejs && \
    node -v && npm -v
RUN dotnet restore "./application.csproj"


# Build and publish the project
RUN dotnet publish "./application.csproj" -c Release -o /app/publish

# ---------------------
# Runtime stage
# ---------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

# Expose default port (80 in container)
EXPOSE 80


ENTRYPOINT ["dotnet", "application.dll"]
