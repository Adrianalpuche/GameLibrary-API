# 🎮 GameLibrary API

A RESTful CRUD API built with **C# and ASP.NET Core 10** for managing a personal video game library. Designed with clean architecture principles using the MVC pattern, DTOs, and Entity Framework Core with MySQL.

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 10 |
| ORM | Entity Framework Core 9 |
| Database | MySQL (via Pomelo EF Provider) |
| Container | Docker |
| API Docs | Swagger / OpenAPI |
| Pattern | MVC + DTOs + Mappers |

---

## 📁 Project Structure

```
GameLibrary.Api/
├── Controllers/        # API route handlers (HTTP layer)
├── Models/             # Entity models (database schema)
├── Dtos/               # Data Transfer Objects (request/response shapes)
├── Mappers/            # Model ↔ DTO conversion logic
├── Data/               # DbContext and EF Core configuration
├── Migrations/         # Entity Framework database migrations
├── docker/container/   # Docker configuration files
└── Program.cs          # App entry point and service registration
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/products/docker-desktop/)

### 1. Start the database with Docker

```bash
cd docker/container
docker-compose up -d
```

### 2. Apply database migrations

```bash
dotnet ef database update
```

### 3. Run the API

```bash
dotnet run
```

The API will be available at `https://localhost:5001`  
Swagger UI: `https://localhost:5001/swagger`

---

## 📡 API Endpoints

### Games

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/games` | Get all games |
| `GET` | `/api/games/{id}` | Get a game by ID |
| `POST` | `/api/games` | Create a new game |
| `PUT` | `/api/games/{id}` | Update an existing game |
| `DELETE` | `/api/games/{id}` | Delete a game |

### Example Request — Create a Game

```http
POST /api/games
Content-Type: application/json

{
  "title": "The Legend of Zelda: Breath of the Wild",
  "genre": "Action-Adventure",
  "platform": "Nintendo Switch",
  "releaseYear": 2017,
  "developer": "Nintendo"
}
```

### Example Response

```json
{
  "id": 1,
  "title": "The Legend of Zelda: Breath of the Wild",
  "genre": "Action-Adventure",
  "platform": "Nintendo Switch",
  "releaseYear": 2017,
  "developer": "Nintendo"
}
```

---

## 🏗️ Architecture Decisions

**DTOs (Data Transfer Objects):** The API never exposes raw entity models directly. Input and output shapes are controlled separately, keeping the data layer decoupled from the HTTP layer.

**Mappers:** Dedicated mapper classes handle the conversion between Models and DTOs, avoiding manual mapping scattered across controllers.

**Entity Framework Code First:** The database schema is defined in C# and version-controlled through EF migrations, making it easy to reproduce the database in any environment.

**Docker for MySQL:** The database runs in a container to ensure every developer works against the same environment, avoiding "works on my machine" issues.

---

## 📦 NuGet Packages

```xml
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.5" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.0" />
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="9.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="10.1.7" />
```

---

## 👤 Author

**Adrian Alpuche**  
[GitHub](https://github.com/Adrianalpuche)
