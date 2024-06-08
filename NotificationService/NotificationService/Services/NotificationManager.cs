using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotificationServiceLibrary.Interfaces;
using NotificationServiceLibrary.Models;

namespace NotificationServiceLibrary.Services
{
    public class NotificationManager
    {
        private readonly Dictionary<string, INotificationService> _services;

        public NotificationManager()
        {
            _services = new Dictionary<string, INotificationService>();
        }

        public void RegisterService(string key, INotificationService service)
        {
            _services[key] = service;
        }

        public async Task<NotificationResponse> SendNotificationAsync(string serviceKey, NotificationRequest request)
        {
            if (_services.ContainsKey(serviceKey))
            {
                var service = _services[serviceKey];
                return await service.SendNotificationAsync(request);
            }

            throw new ArgumentException("Invalid service key");
        }
    }
}
