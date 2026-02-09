using Microsoft.AspNetCore.Identity;

namespace MathTestSystem.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int ProfileId { get; set; }
        public string Role { get; set; }
    }
}
