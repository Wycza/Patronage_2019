using BookRoom.Application.Interfaces;
using BookRoom.Application.Notifications.Models;
using System.Threading.Tasks;

namespace BookRoom.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
