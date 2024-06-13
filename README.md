Notification Service Class Library
Overview

The Notification Service class library provides a flexible and extensible solution for sending notifications across different channels, such as Email and Push notifications. It is designed for easy integration and future expansion to support additional notification providers like SMS and Slack.

Features

    Multi-Channel Support: Send notifications via Email and Push notifications.
    Extensibility: Easily add support for new notification providers.
    Asynchronous Processing: Non-blocking and efficient notification sending.
    Unique Identifiers: Each notification is assigned a unique GUID.
    Developer Friendly: Simple to integrate and use in various projects.

Installation
    Clone the repository:
https://github.com/shayanshani/CuraAssignments.git

Build the project:
    Add the library to your project by including it as a project reference or adding the compiled DLL.

Usage

    Initialize the Notification Manager and add providers:


var notificationManager = new NotificationManager();
notificationManager.AddProvider(new EmailNotificationProvider());
notificationManager.AddProvider(new PushNotificationProvider());

Create and send a notification:


    var notification = new Notification
    {
        Recipient = "user@example.com",
        Subject = "Breaking News",
        Message = "This is a test notification."
    };

    var result = await notificationManager.SendAsync(notification);
    Console.WriteLine($"Notification sent with ID: {result.NotificationId}");

Extending the Service

To add a new notification provider, implement the INotificationProvider interface and register the provider with the NotificationManager.

Example for adding an SMS provider:



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
``
notificationManager.AddProvider(new SmsNotificationProvider());
``
