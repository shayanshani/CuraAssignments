using System.Threading.Tasks;
using NotificationServiceLibrary.Interfaces;
using NotificationServiceLibrary.Models;

namespace NotificationServiceLibrary.Services
{
    public abstract class BaseNotificationService : INotificationService
    {
        public abstract Task<NotificationResponse> SendNotificationAsync(NotificationRequest request);
    }
}
