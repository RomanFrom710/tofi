namespace TOFI.TransferObjects.User.Queries
{
    public class LoginQuery : Query
    {
        public string Username { get; set; }

        public string Email { get; set; }
    }
}