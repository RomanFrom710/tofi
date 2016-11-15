namespace TOFI.TransferObjects.User.Queries
{
    public class UserInfoQuery : Query
    {
        public int? Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}