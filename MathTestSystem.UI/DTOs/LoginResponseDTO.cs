namespace MathTestSystem.UI.DTOs
{
    public class LoginResponseDTO
    {
        public string UserName { get; set; }
        public string[] Roles { get; set; }
        public string Token { get; set; }
        public int ProfileId { get; set; }
    }
}
