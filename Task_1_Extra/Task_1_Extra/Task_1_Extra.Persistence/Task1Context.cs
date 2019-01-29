using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task_1_Extra.Domain.Entities;

namespace Task_1_Extra.Persistence
{
    public class Task1Context : IdentityDbContext<AppUser>
    {
        public Task1Context(DbContextOptions<Task1Context> options) : base(options)
        {
        }
    }
}
