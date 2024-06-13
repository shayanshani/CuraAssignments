# Custom Logging Library for .NET

## Overview

This custom logging library for .NET provides a flexible and extensible logging solution that supports multiple output targets such as console and file logging. It is designed to be easily integrated into various .NET projects and allows for the addition of new logging providers.

## Features

- **Multi-Target Logging**: Supports logging to console and files.
- **Extensible Architecture**: Easily add new logging providers.
- **Configurable**: Allows configuration of logging levels and output formats.
- **Asynchronous Logging**: Non-blocking and efficient logging.
- **Unique Identifiers**: Each log entry is assigned a unique GUID.

## Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/shayanshani/CuraAssignments.git
    ```

2. **Build the project**

3. **Add the library to your project**:
    - Add as a project reference or include the compiled DLL in your project.

## Usage

1. **Initialize the Logger and add log providers**:
    ```csharp
    var logger = new Logger();
    logger.AddProvider(new ConsoleLogProvider());
    logger.AddProvider(new FileLogProvider("logs.txt"));
    ```

2. **Log messages**:
    ```csharp
    logger.Log(LogLevel.Info, "This is an info message.");
    logger.Log(LogLevel.Error, "This is an error message.");
    ```

3. **Configure logging levels**:
    ```csharp
    var logger = new Logger();
    logger.SetLogLevel(LogLevel.Warning); // Only logs warnings and above
    logger.AddProvider(new ConsoleLogProvider());
    ```

## Extending the Service

To add a new logging provider, implement the `ILogProvider` interface and register the provider with the `Logger`.

Example for adding a database log provider:
```csharp
public class DatabaseLogProvider : ILogProvider
{
    public async Task LogAsync(LogEntry entry)
    {
        // Simulate logging to database
        var logId = Guid.NewGuid();
        await Task.Delay(100);
        Console.WriteLine($"Logged to database with ID: {logId}");
    }
}

// Add to logger
logger.AddProvider(new DatabaseLogProvider());
```

## Configuration

- **Logging Levels**: Configure which levels of logs to record (e.g., Info, Warning, Error).
- **Output Targets**: Specify where logs should be written (e.g., console, file, database).
- **Log Format**: Customize the format of log messages as needed.

