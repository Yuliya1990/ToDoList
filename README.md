# ToDoList API

A classic To-Do List micro-application built with **.NET 8 Web API** and **C#**, following **DDD**, **CQRS** (via MediatR), **IoC**, and **EF Code-First** design patterns. Includes an Outbox pattern for reliable event publishing to RabbitMQ and a separate Notification Worker Service.

---

## Architecture

![Architecture Diagram](Architechture.png)

The application follows a layered architecture:

- **Presentation Layer** — REST API endpoints (GET / POST / PATCH / DELETE)
- **Application Layer** — MediatR CQRS dispatcher, Commands, Queries, Handlers
- **Domain Layer** — Domain models, repository interfaces, domain events
- **Infrastructure Layer** — EF Core persistence, migrations, repository implementations, RabbitMQ publisher, Outbox background service
- **Notification Service** — RabbitMQ consumer that handles events

---

## Projects (`ToDoList.sln`)

| Project                        | Type           | Role                                                                           |
| ------------------------------ | -------------- | ------------------------------------------------------------------------------ |
| `ToDoList.Domain`              | Class Library  | Entities, repository interfaces, domain events                                 |
| `ToDoList.Application`         | Class Library  | MediatR commands, queries, handlers, DTOs                                      |
| `ToDoList.Infrastructure`      | Class Library  | AppDbContext, EF configs, repositories, RabbitMQ publisher, background service |
| `ToDoList.API`                 | Web API        | Controllers, Program.cs, IoC wiring, Swagger                                   |
| `ToDoList.NotificationService` | Worker Service | RabbitMQ consumer, notification handlers                                       |

### Project Reference Chain

```
ToDoList.API
├── ToDoList.Application
│   └── ToDoList.Domain
└── ToDoList.Infrastructure
    └── ToDoList.Domain

ToDoList.NotificationService
└── ToDoList.Domain
```

---

## Tech Stack

| Concern         | Technology                         |
| --------------- | ---------------------------------- |
| Framework       | .NET 8 Web API                     |
| ORM             | Entity Framework Core (Code-First) |
| CQRS Dispatcher | MediatR                            |
| Database        | SQL Server                         |
| Message Broker  | RabbitMQ                           |
| API Docs        | Swagger / Swashbuckle              |

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local or remote)
- RabbitMQ (e.g. via Docker: `docker run -d -p 5672:5672 -p 15672:15672 rabbitmq:management`)

### Run

```bash
# Apply EF migrations
dotnet ef database update -p ToDoList.Infrastructure -s ToDoList.API

# Start the API
dotnet run --project ToDoList.API

# Start the Notification Worker
dotnet run --project ToDoList.NotificationService
```

Swagger UI will be available at `https://localhost:{port}/swagger`.
