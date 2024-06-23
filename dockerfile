# Stage 1: Restore dependencies (uses .NET SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore-stage
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Debug -o out

# Stage 2: Build the image (doesn't require .NET SDK)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=restore-stage /app/ .

# Publish the application


# Set the working directory for the application
WORKDIR /app/out

# Start the application
CMD ["dotnet", "PostRedisApi.dll"]
