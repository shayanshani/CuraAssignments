# Centralized Caching Layer for .NET Core Web API

## Overview

The Centralized Caching Layer is designed to optimize a .NET Core Web API by caching responses to reduce redundant processing and data querying. It uses MSSQL for storing cached responses and automatically handles cache invalidation after 2 hours.

## Features

- **Centralized Caching**: Caches responses centrally in an MSSQL database.
- **Cache Expiry**: Automatically invalidates cached data after 2 hours.
- **Parameter-Based Caching**: Caches responses based on request parameters.
- **Stateless API Support**: Suitable for stateless APIs in clustered environments.
- **Extensible and Maintainable**: Designed for easy integration and future extension.

## Setup and Installation

### Prerequisites

- .NET Core SDK 8.0 or later.
- MSSQL Server (LocalDB or full instance).
- Visual Studio or Visual Studio Code.

### Installation Steps

1. **Clone the repository**:
    ```bash
    https://github.com/shayanshani/CuraAssignments
    ```

2. **Install dependencies**:
    ```bash
    dotnet restore
    ```

3. **Configure the database**:
    - Open `appsettings.json` and set up the connection string for your MSSQL instance.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=.;Database=CacheDb;Trusted_Connection=True;"
      }
    }
    ```

4. **Run migrations** to create the database schema:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

5. **Run the application**:
    ```bash
    dotnet run
    ```

## Usage

1. **Integrate the caching middleware** in your `Program.cs`:
    ```csharp
    var builder = WebApplication.CreateBuilder(args);
    
    // Add services
    builder.Services.AddControllers();
    builder.Services.AddDbContext<CacheDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<ICacheService, CacheService>();
    
    var app = builder.Build();
    
    // Use middleware
    app.UseMiddleware<CacheMiddleware>();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
    ```

2. **Make requests to your API endpoints**. The caching middleware will automatically cache responses based on request parameters and store them in the MSSQL database.

## Extending the Cache

To extend the cache middleware:

1. **Implement custom caching logic** in the `CacheService` to handle different caching strategies.
2. **Update the `CacheMiddleware`** to support additional features or integrate with other systems.

## Configuration

- **Database Connection**: Adjust the connection string in `appsettings.json` to connect to your MSSQL server.
- **Cache Expiry**: Cache entries are set to expire after 2 hours. Modify the logic in `CacheService` if you need a different expiry policy.
