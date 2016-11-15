namespace TOFI.TransferObjects.Auth.Queries
{
    public class LoginQuery : Query
    {
        public string Username { get; set; }

        public string Email { get; set; }
    }
}