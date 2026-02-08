using MathTestSystem.Domain.Enums;

namespace MathTestSystem.Domain.Entites
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public int ReferenceId { get; set; } // Student/Teacher ID
    }

}