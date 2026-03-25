# Accounting Settle-Up System

## Tech Stack
- .NET 10
- Entity Framework Core 10
- PostgreSQL
- Swagger + Scalar

---

## Prerequisites
- .NET 10 SDK
- Docker

---

## Setup

### 1. Start PostgreSQL

```bash
docker run --name postgres-db \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=postgres \
  -e POSTGRES_DB=settleup \
  -p 5432:5432 \
  -d postgres