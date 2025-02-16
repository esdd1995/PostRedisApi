# PostRedisApi: A .NET Core 8 Web API with PostgreSQL and Redis Caching

This project implements a .NET Core 8 web API utilizing PostgreSQL as the primary database and Redis for caching purposes.

## Features

* Built with ASP.NET Core 8
* Leverages Entity Framework Core for database access (PostgreSQL)
* Integrates StackExchange.Redis for in-memory caching

## Running the API

**Prerequisites:**

* Docker installed (https://www.docker.com/)

**Instructions:**

1. Clone this repository.
2. Open a terminal in the project directory.
3. Run the following command to start the API with Docker Compose:

   ```bash
   docker-compose up -d
