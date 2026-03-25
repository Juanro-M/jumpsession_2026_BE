Got it — I’ll make a **single `README.md` file** with **all content in one continuous flow**, no escaping, no multiple sections breaking it up. Everything stays in one Markdown file, including commands and instructions.

Here’s the full unified version:

````markdown
# 📌 Accounting Settle-Up System

A backend API for expense and group management using .NET 8, Entity Framework Core 8, and PostgreSQL.

## Prerequisites

- .NET 8 SDK: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
- Docker (for PostgreSQL): https://www.docker.com/
- Optional IDE: Visual Studio, Rider, or VS Code

## Setup Instructions

1. **Clone the repository**

```bash
git clone <your-repo-url>
cd "Accounting Settle-Up System/Accounting Settle-Up System"
````

2. **Run PostgreSQL in Docker**

```bash
docker run --name postgres-db -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=settleup -p 5432:5432 -d postgres
```

3. **Update `appsettings.json` connection string**

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

4. **Install EF Core CLI**

```bash
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 8.0.11
dotnet ef --version
```

5. **Restore dependencies and clean**

```bash
dotnet clean
dotnet nuget locals all --clear
dotnet restore
```

6. **Create and apply migrations**

```bash
dotnet ef migrations add Init
dotnet ef database update
```

7. **Run the application**

```bash
dotnet run
```

* API URL: [https://localhost:5001](https://localhost:5001)
* Swagger UI: [https://localhost:5001/swagger](https://localhost:5001/swagger)

8. **Optional: Scalar API Reference UI**

* Provides an interactive API reference in development mode.
* Automatically configured if `Scalar.AspNetCore` is included.

9. **Clean & rebuild project**

```bash
dotnet clean
dotnet build
```

10. **Docker cleanup (optional)**

```bash
docker stop postgres-db
docker rm postgres-db
```

## Notes

* Target framework: net8.0
* EF Core: 8.0.11
* PostgreSQL provider: Npgsql.EntityFrameworkCore.PostgreSQL 8.0.11
* Do not use .NET 10 / Npgsql 10 preview — migrations will fail due to missing EF Core APIs.

```
