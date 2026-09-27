# Overview

The **Help Desk API** is a clean, minimal, and fully functional RESTful service designed to manage support operations. It handles core CRUD workflows for two primary entities: **Customers** and **Tickets**, maintaining full relationship linking (tickets are tied directly to specific customers via foreign keys).

The architecture leverages a strict separation of concerns using:
* **Controllers**: For HTTP routing, request handling, and returning status codes.
* **Data Transfer Objects (DTOs)**: For strict payload validation and mapping.
* **Services**: For encapsulation of business logic and in-memory list persistence.

In modern business operations, customer satisfaction directly correlates with how efficiently technical issues and inquiries are handled. Organizations often struggle with fragmented communication channels (such as scattered emails or unstructured chat threads) when tracking customer complaints, leading to delayed response times, lost tickets, and poor visibility into critical system bottlenecks.

The purpose of this project is to build a centralized, robust backend infrastructure that solves these operational challenges by:
* **Centralizing Support Records**: Unifying customer profiles and support tickets into a single, structured relational data flow to eliminate lost or untracked inquiries.
* **Enabling Proactive Prioritization**: Allowing support teams to categorize issues by urgency (`Low`, `Medium`, `High`) and lifecycle status (`Open`, `Progress`, `Resolved`) to ensure critical customer pain points are addressed immediately.
* **Streamlining Query Workflows**: Providing dynamic filtering capabilities so administrators and support agents can instantly query tickets by status, priority, or specific customer account to audit open items efficiently.

[Software Demo Video](https://www.loom.com/share/ca29776203b8454e894b1addaa6e0172)

# Development Environment

* **.NET SDK (.NET 10)**: The core framework and runtime environment (v10.0.203) used to compile and execute the application.
* **.NET CLI**: Used via the terminal for building and running project commands (`dotnet run`).
* **C#**: Utilized modern language features including nullable reference types, strict type safety, pattern matching, DTO constructs, and LINQ.
* **Postman**: Used for manual endpoint testing and payload validation.

# Useful Websites

* [Official ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-10.0)
* [C# Guide and Language Reference](https://learn.microsoft.com/en-us/dotnet/csharp/)
* [RESTful API Design Best Practices](https://learn.microsoft.com/en-us/azure/architecture/best-practices/api-design)
