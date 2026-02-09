namespace MathTestSystem.UI.Services
{
    using MathTestSystem.UI.DTOs;
    public class AuthStateService
    {
        public LoggedUserDTO? CurrentUser { get; private set; }

        public bool IsAuthenticated => CurrentUser != null;

        public void Login(LoggedUserDTO user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }

}
