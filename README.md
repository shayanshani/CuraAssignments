# Notification Service Class Library

## Overview

The Notification Service class library provides a flexible and extensible solution for sending notifications across different channels, such as Email and Push notifications. It is designed for easy integration and future expansion to support additional notification providers like SMS and Slack.

## Features

- **Multi-Channel Support**: Send notifications via Email and Push notifications.
- **Extensibility**: Easily add support for new notification providers.
- **Asynchronous Processing**: Non-blocking and efficient notification sending.
- **Unique Identifiers**: Each notification is assigned a unique GUID.
- **Developer Friendly**: Simple to integrate and use in various projects.

## Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/shayanshani/CuraAssignments.git
    ```

2. **Build the project**:

3. **Add the library to your project**:
    - Add as a project reference or include the compiled DLL in your project.

## Usage

1. **Initialize the Notification Manager and add providers**:
    ```csharp
    var notificationManager = new NotificationManager();
    notificationManager.AddProvider(new EmailNotificationProvider());
    notificationManager.AddProvider(new PushNotificationProvider());
    ```

2. **Create and send a notification**:
    ```csharp
    var notification = new Notification
    {
        Recipient = "user@example.com",
        Subject = "Breaking News",
        Message = "This is a test notification."
    };

    var result = await notificationManager.SendAsync(notification);
    Console.WriteLine($"Notification sent with ID: {result.NotificationId}");
    ```

## Extending the Service

To add a new notification provider, implement the `INotificationProvider` interface and register the provider with the `NotificationManager`.

Example for adding an SMS provider:
```csharp
public class SmsNotificationProvider : INotificationProvider
{
    public async Task<NotificationResult> SendAsync(Notification notification)
    {
        // Simulate sending SMS
        var notificationId = Guid.NewGuid();
        await Task.Delay(100);
        return new NotificationResult
        {
            NotificationId = notificationId,
            Status = NotificationStatus.Sent
        };
    }
}

// Add to manager
notificationManager.AddProvider(new SmsNotificationProvider());
```
