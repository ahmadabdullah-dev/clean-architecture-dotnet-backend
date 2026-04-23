# Clean Architechure dotnet backend

## Overview
A  clean .NET backend with clean architechure principles, ensuring separation of concerns and maintainability across layers.

## Project Structure

### Domain
The innermost layer with no external dependencies. Contains:

- **Entities** — core business objects with identity and lifecycle
- **Enums** — strongly-typed domain enumerations
- **Exceptions** — domain-specific exceptions 
- **Value Objects** — immutable, equality-by-value domain concepts
- **Events** — domain events for decoupled side-effect handling
- **Constants** — domain-wide constant values

### Packages
- **MediatR** — mediator pattern for CQRS command/query dispatching and domain event handling
- **Microsoft.EntityFrameworkCore.Identity** — identity and user management primitives
