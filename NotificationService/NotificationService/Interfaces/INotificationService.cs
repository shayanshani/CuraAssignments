using NotificationServiceLibrary.Models;
using System.Threading.Tasks;

namespace NotificationServiceLibrary.Interfaces
{
    public interface INotificationService
    {
        Task<NotificationResponse> SendNotificationAsync(NotificationRequest request);
    }
}
