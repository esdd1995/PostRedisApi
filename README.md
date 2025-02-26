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
### Environment Setup
You need to set `POSTGRES_PASSWORD`, `POSTGRES_USER`, and `POSTGRES_DB` in the [docker-compose.yml](docker-compose.yml) and match them with [appsettings.json](app/api/appsettings.json).
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


## Debugging
### .Net Remote Debugger
This project utilizes `remote_debugger` for .Net. 
See api [Dockerfile](app/api/Dockerfile)  for more information.

To debug the .NET Core API using Visual Studio Code attach a debugger, the configuration is defined in [launch.json](.vscode/launch.json).

after starting the containers:
1. **Attach the Debugger**:
   - In Visual Studio Code, go to the Debug view by clicking the Debug icon in the Activity Bar on the side of the window.
   - Select the ".NET Core Docker Attach" configuration from the dropdown menu at the top.
   - Press `F5` to start debugging.
   - When prompted, select the process `.dll` to attach to . 
2. **Set Breakpoints**:
   - Open the `.cs` files where you want to set breakpoints.


Once the debugger is attached, you can hit breakpoints, inspect variables, and step through code as you would in a local debugging session.

### Hot Reload
The Vue.js frontend supports hot reload. Any changes made to the frontend code will be automatically reflected in the browser without needing to restart the Docker container.
see frontend [Dockerfile](app/frontend/Dockerfile) for more information.


## Project Structure
```sh
PostRedisApi/
├── .vscode
├── └──launch.json
├── app/
│   ├── api/
│   │   ├── Controllers/
│   │   ├── Data/
│   │   ├── Models/
│   │   ├── Migrations/
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   └── dockerfile
│   ├── frontend/
│   │   ├── public/
│   │   ├── src/
│   │   ├── vue.config.js
│   │   ├── package.json
│   │   └── dockerfile
└── docker-compose.yml
```

## License
This project is licensed under the MIT License.
