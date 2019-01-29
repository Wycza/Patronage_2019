using BookRoom.Application.Notifications.Models;
using System.Threading.Tasks;

namespace BookRoom.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
