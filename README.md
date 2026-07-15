# Word Collection API

A RESTful ASP.NET Core 8 Web API that allows users to create, retrieve, update, delete, and search a collection of words grouped by their word types.

## Features

- Create a word
- Retrieve all words
- Retrieve a word by Id
- Retrieve a word by name
- Update a word
- Delete a word
- Search by:
  - Word
  - Word Type
- Pagination
- Logging with Serilog
- Entity Framework Core
- SQL Server (LocalDB)
- Repository Pattern
- Orchestration Layer
- Dependency Injection

---

## Word Types

The API supports the following word types:

- Noun
- Verb
- Adjective
- Adverb
- Pronoun
- Preposition
- Interjection
- Conjunction
- Determiner

---

## Technology Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- Serilog
- Swagger/OpenAPI

---

## Architecture

```
Controller
      │
      ▼
Orchestration
      │
      ▼
Repository
      │
      ▼
Entity Framework Core
      │
      ▼
SQL Server
```

---

## Project Structure

```
Controllers/
Data/
DTOs/
Enums/
Models/
Orchestration/
Repository/
Properties/
Program.cs
appsettings.json
```

---

## Getting Started

### Clone the repository

```bash
git clone https://github.com/phiwe-saba/word-collection.git
```

### Restore packages

```bash
dotnet restore
```

### Apply migrations

```bash
dotnet ef database update
```

### Run the application

```bash
dotnet run
```

Swagger

```
https://localhost:7272/swagger
```

---

## API Endpoints

| Method | Endpoint | Description |
|---------|----------|-------------|
| GET | /api/WordCollection/getAllWords | Retrieve all words |
| GET | /api/WordCollection/getWordById/{id} | Retrieve word by Id |
| GET | /api/WordCollection/getWordByName/{word} | Retrieve word by name |
| POST | /api/WordCollection/createWord | Create word |
| PUT | /api/WordCollection/updateWordById/{id} | Update word |
| DELETE | /api/WordCollection/deleteWordById/{id} | Delete word |
| POST | /api/WordCollection/searchWords | Filter & paginate words |
| GET | /api/WordCollection/getWordTypes | Retrieve available word types |

---

## Logging

Serilog is configured to generate daily rolling log files.

Log Levels

- Information
- Error

Logs are written to:

```
Logs/
```

---

## CI/CD

GitHub Actions is configured for Continuous Integration.

Pipeline performs:

- Restore packages
- Build solution
- Publish artifacts

---

## Future Improvements

- Authentication & Authorization
- Unit Tests
- Integration Tests
- Docker Support
- API Versioning

---

## Author

Sibulele Saba
