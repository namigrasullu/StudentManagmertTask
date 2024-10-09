# StudentManagmertTask
## Overview

This project demonstrates how to set up a SQL Server database using Docker and update it using Entity Framework Core (EF Core). 

## Prerequisites

- Docker installed on your machine
- .NET SDK installed (with EF Core tools)

## Setup SQL Server with Docker

To run SQL Server in a Docker container, execute the following command in your terminal:

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Admin12!" -p 1433:1433 --name sqlserver-container -d mcr.microsoft.com/mssql/server:2022-latest
