using Microsoft.AspNetCore.Identity;

namespace Task_1_Extra.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string SecondName { get; set; }
    }
}
