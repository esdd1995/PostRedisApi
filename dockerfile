# Stage 1: Restore dependencies (uses .NET SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore-stage
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Debug -o out

## Run migrations
FROM restore-stage as migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet-ef database update --project /app

# Stage 2: Build the image (doesn't require .NET SDK)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=restore-stage /app/ .

# Install the .NET Core debugger
RUN apt-get update \
    && apt-get install -y --no-install-recommends unzip curl \
    && rm -rf /var/lib/apt/lists/* \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /remote_debugger \
    && ls -la /remote_debugger

# Set the working directory for the application
WORKDIR /app/out
# Start the application
CMD ["dotnet", "PostRedisApi.dll"]