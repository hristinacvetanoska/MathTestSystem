namespace MathTestSystem.UI.Services
{
    public class AuthStateService
    {
        public string UserName { get; private set; }
        public string[] Roles { get; private set; }
        public string Token { get; private set; }
        public int ProfileId { get; private set; }

        public bool IsAuthenticated { get; private set; } = false;

        public void Login(string username, string[] roles, string token, int profileId)
        {
            UserName = username;
            Roles = roles;
            Token = token;
            ProfileId = profileId;
            IsAuthenticated = true;
        }

        public void Logout()
        {
            UserName = null;
            Roles = null;
            Token = null;
            ProfileId = 0;
            IsAuthenticated=false;
        }
    }

}
