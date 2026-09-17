## What this is

This is a small ASP.NET Core Web API sample that demonstrates API versioning in a real EF Core + SQL Server project. The app exposes versioned endpoints for stadium data, with v1 returning a minimal payload and v2 adding more fields, and it configures version selection through query string, URL segment, or header.

### Stack
- Language(s): C#
- Framework / runtime: ASP.NET Core Web API on .NET 10
- Notable libraries:
  - Asp.Versioning.Mvc for API versioning
  - Microsoft.EntityFrameworkCore for data access
  - Microsoft.EntityFrameworkCore.SqlServer for SQL Server
  - ASP.NET Core MVC / controllers

## How it's organized

```text
AspNetWebApiVersionsing.slnx          solution file
AspNetWebApiVersionsing/              main app project
  Controllers/
    V1/                              v1 endpoint demo
    V2/                              v2 endpoint demo
  Data/
    LeagueManagerDbContext.cs         EF Core DbContext and model mapping
  Models/                            domain models
  Program.cs                         app startup and versioning config
  appsettings.json                   DB connection string + logging
  appsettings.Development.json
  Properties/
```

How it fits together: `Program.cs` registers `AddApiVersioning`, sets `DefaultApiVersion` to `1.0`, and combines version readers from query string (`api-version`), URL segment (`api/v{version}`), and `X-Api-Version` header. `LeagueManagerDbContext` maps a sports domain model to SQL Server; the controllers in `Controllers/V1` and `Controllers/V2` expose the same `Stadiums` resource with different shapes. The versioned controller code shows the intended behavior: v1 returns `Id`, `Name`, and `BuiltYear`, while v2 adds `PitchLength`, `PitchWidth`, and `City`.

## How to run it

From a fresh clone:

```bash
dotnet restore
dotnet build
dotnet run --project AspNetWebApiVersionsing
```

A SQL Server database named `PremierLeagueAppDb` is expected by the connection string in `appsettings.json`, so you’ll need a local or reachable SQL Server instance before the app can fully serve requests. The project is meant as a demo, not a production-ready service.

## Try asking

- How does the app choose between `api/v1/stadiums`, `?api-version=2`, and `X-Api-Version`?
- Where is the stadium schema defined, and which fields are present in v1 vs v2?
- Can this sample be adapted to a more realistic multi-version API with separate contracts and DTOs?

