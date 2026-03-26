# 📌 Accounting Settle-Up System

A backend API for expense and group management built with .NET 10, Entity Framework Core 10, and PostgreSQL.

---

## 🛠 Tech Stack

* **Target Framework:** .NET 10 (`net10.0`)
* **ORM:** Entity Framework Core 10.0.0
* **Database Provider:** `Npgsql.EntityFrameworkCore.PostgreSQL` 10.0.0

## 📋 Prerequisites

* [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
* [Docker](https://www.docker.com/) (for hosting PostgreSQL locally)
* **Recommended IDE:** Visual Studio, JetBrains Rider, or VS Code

---

## 🚀 Setup Instructions

### 1. Clone the Repository

```bash
git clone <your-repo-url>
cd "Accounting Settle-Up System/Accounting Settle-Up System"
```

### 2. Run PostgreSQL in Docker

Spin up a local PostgreSQL instance:

```bash
docker run --name postgres-db -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=admin -e POSTGRES_DB=accounting_settle_up -p 5432:5432 -d postgres
```

### 3. Update Configuration

Ensure your `appsettings.json` connection string matches the Docker setup:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=accounting_settle_up;Username=admin;Password=admin"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 4. Install EF Core CLI

If you don't have the latest .NET 10 EF Core tools installed globally:

```bash
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 10.0.0
dotnet ef --version
```

### 5. Restore and Build

Clear local caches, restore dependencies, and build the project:

```bash
dotnet clean
dotnet nuget locals all --clear
dotnet restore
dotnet build
```

### 6. Apply Database Migrations

Create the initial schema and update the database:

```bash
dotnet ef migrations add Init
dotnet ef database update
```

### 7. Run the Application

```bash
dotnet run --project "Accounting Settle-Up System"
```

---

## 📖 API Documentation

Once the application is running, you can interact with the API via:

* **Base API URL:** [https://localhost:5001](https://localhost:5001)
* **Swagger UI:** [https://localhost:5001/swagger](https://localhost:5001/swagger)
* **Scalar API Reference:** If `Scalar.AspNetCore` is included in the project, an interactive UI is available in development mode.

---

## 🧹 Teardown & Cleanup

When you are finished, you can stop and remove the PostgreSQL container to free up resources:

```bash
docker stop postgres-db
docker rm postgres-db
```