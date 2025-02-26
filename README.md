# PostRedisApi Project

## Overview

The PostRedisApi project is a full-stack application that includes a .NET Core Web API, a Vue.js frontend, and a PostgreSQL database. The project is containerized using Docker and supports features such as hot reload for the frontend, debugging for the .NET Core API, and persistent data storage for the PostgreSQL database.

## Features

- **.NET Core Web API**: Provides endpoints for managing products.
- **Vue.js Frontend**: A user interface for interacting with the API.
- **PostgreSQL Database**: Stores product data.
- **Redis**: Used for caching.
- **Docker**: Containerizes the entire application for easy deployment and development.
- **Hot Reload**: Supports hot reload for the Vue.js frontend.
- **Debugger**: Supports debugging for the .NET Core API using Visual Studio Code.

## Prerequisites

- Docker
- Docker Compose
- Visual Studio Code (for debugging)

## Getting Started

### Docker Compose
Use Docker Compose to build and run the application:
```sh 
docker-compose up --build
```
This command will:

* Build the Docker images for the API and frontend.
* Start the PostgreSQL and Redis containers.
* Start the API and frontend containers.
### Accessing the Application
* API: http://localhost:8080
* Frontend: http://localhost:3000

### Hot Reload
The Vue.js frontend supports hot reload. Any changes made to the frontend code will be automatically reflected in the browser without needing to restart the Docker container.

### Debugging
To debug the .NET Core API using Visual Studio Code attach a debuger, the cofiguration is defined in `.vscode/launch.json`.