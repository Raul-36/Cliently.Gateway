# Cliently.Gateway

This is the API Gateway for the Cliently application, built with ASP.NET Core and Ocelot.

## Overview

The gateway acts as a single entry point for all client requests and routes them to the appropriate downstream services.

- Requests to `/api/identity/*` are routed to the `Cliently.IdentityService`.
- Requests to `/api/business/*` are routed to the `Cliently.BusinessInfoService`.

## Running the Gateway

The gateway is configured to run as part of the main `docker-compose.yml` file located in `Cliently.Infrastructure/docker`.

To run the entire application, including the gateway:

```bash
cd ../Cliently.Infrastructure/docker
docker-compose up -d --build
```

The gateway will be available at `http://localhost:8000`.
