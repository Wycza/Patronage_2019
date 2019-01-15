using Microsoft.EntityFrameworkCore;

namespace Task_1_Extra.Persistence
{
    public class Task1Context : DbContext
    {
        public Task1Context(DbContextOptions<Task1Context> options) : base(options)
        {
        }
    }
}
