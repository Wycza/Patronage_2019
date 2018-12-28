using System.Threading.Tasks;

namespace Task_1_Extra.Application.Interfaces
{
    public interface IMockioService
    {
        Task<string> GetResponseAsync(string url);
    }
}
