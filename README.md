# Project Overview

This project is built using **.NET 10** and follows a **multitier architecture** approach.  
The chosen architecture emphasizes **clarity, separation of concerns, and maintainability**, while intentionally avoiding unnecessary complexity.

Given the simplicity of the problem domain, more advanced architectural patterns such as **Hexagonal**, **Clean (Onion) Architecture** were deliberately not used. While those patterns are powerful, applying them here would introduce unnecessary abstraction and boilerplate without providing meaningful benefits.

---

## Architecture Overview

The application is structured into three logical layers:

```Console → Services → Repositories```

Besides the 3 layers there is one separate project added for Domain models (Domain) and another one for Infrastructure (in this case Logging).

Each layer has a clearly defined responsibility:

### Console
- Application entry point
- Composition root (Dependency Injection setup)
- Configuration loading
- Orchestrates application flow

### Services
- Contains business logic
- Coordinates validation, processing, and notifications
- Depends only on abstractions, not implementations

### Repositories
- Handles data access
- Uses in-memory storage for simplicity
- Designed to be easily replaceable with persistent storage

### Domain
- contains Domain models - in this case it is `Order` DTO

### Infrastructure
- Handles Logger implementation
- Might be a good place for other crosscutting code

---

## Project Structure & Abstractions

Each layer is implemented as a **separate project** within the solution.

All interfaces are placed inside an `Abstractions` namespace within their respective modules.  
This follows the same convention used by Microsoft in packages such as:

```
Microsoft.Extensions.DependencyInjection
Microsoft.Extensions.DependencyInjection.Abstractions
```
This approach provides several benefits:

- Clear separation between contracts and implementations
- Easier unit testing and mocking
- Consistent and familiar structure
- Avoids premature complexity

Although splitting abstractions into dedicated projects is common in large-scale systems, doing so here would add unnecessary overhead. Keeping abstractions within their respective modules strikes a good balance between **clean architecture** and **pragmatism**.

# How to Run

The application is implemented as a **console application**.

After cloning or checking out the repository, make sure to run the project named: `InterviewOneExpert.Console`.

This project serves as the **entry point** of the application and contains:
- Dependency Injection configuration
- Application startup logic
- Execution of the order processing flow

## Running the Application

You can run the application by using Visual Studio:

1. Open the solution.
2. Set **InterviewOneExpert.Console** as the startup project.
3. Press **F5** or **Ctrl + F5**.

## Running Unit Tests

Unit tests are provided for the Services layer and are located in the following project: `InterviewOneExpert.Services.Tests.Unit`.

For clarity and maintainability, all test projects are placed under the tests folder in the solution.

### What Is Covered by Tests

- Service layer logic
- Order processing flow
- Validation logic
- Error handling
- Notification triggering
- Repository interaction (via mocks)

The tests use:
- xUnit for test framework
- Moq for mocking dependencies

# List of Completed Bonus Tasks

## Asynchronous Processing
The application was updated to use asynchronous processing based on the requirements described in the instructions document.  
All relevant methods were converted to `async/await`, and asynchronous execution is now used throughout the service and repository layers.

---

## Add Order (CRUD)
A new method was added to `IOrderRepository` to support adding orders.

In addition, an `AddOrder` method was introduced in `IOrderService` to keep the responsibility hierarchy consistent.  
This ensures that:
- The service layer remains the main entry point for business logic
- The repository layer is only responsible for data access

---

## IOrderValidator
Order validation logic was extracted into a dedicated `IOrderValidator` interface.

Currently, it validates the order ID, but the abstraction allows easy extension in the future (e.g. business rules, format validation, etc.).  
This improves separation of concerns and testability.

---

## Unit Tests
Unit tests were added for the **Services** layer and are located in the following project: `InterviewOneExpert.Services.Tests.Unit`.

The tests cover:
- Order processing logic
- Validation behavior
- Error handling
- Interaction with dependencies (via mocks)

All tests are placed under the `tests` folder for better solution structure and clarity.

---

## Configuration via appsettings.json
Application configuration is loaded from `appsettings.json`.

The logging configuration uses:
- The **Options Pattern**
- A strongly typed configuration object
- Enum-based log levels for better extensibility

This approach follows recommended .NET best practices and allows easy future extension.

---

## Notification Service
A simple (dummy) notification service was added.

- Implements `INotificationService`
- Sends notifications using `Console.WriteLine`
- Is invoked only after successful order processing

The service is designed to be easily replaced with a real implementation (e.g. email, message queue, or external service) in the future.