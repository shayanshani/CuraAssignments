using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NotificationServiceLibrary.Models;
using Newtonsoft.Json;

namespace NotificationServiceLibrary.Services
{
    public class PushNotificationService : BaseNotificationService
    {
        public override async Task<NotificationResponse> SendNotificationAsync(NotificationRequest request)
        {
            var result = new NotificationResponse
            {
                NotificationId = request.NotificationId
            };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var endpoint = "https://api.pushnotificationservice.com/send"; // i will probaby save push notifications to database table
                    var payload = new
                    {
                        to = request.Recipient,
                        title = request.Subject,
                        body = request.Message
                    };

                    var payloadJson = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(endpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Success = false;
                        result.ErrorMessage = $"Error: {response.StatusCode}";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
