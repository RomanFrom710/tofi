namespace TOFI.TransferObjects.User.Commands
{
    public class RegisterCommand : Command
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}