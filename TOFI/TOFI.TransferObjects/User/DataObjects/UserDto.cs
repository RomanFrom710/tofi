namespace TOFI.TransferObjects.User.DataObjects
{
    public class UserDto : Dto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool EmailConfirmed { get; set; }
    }
}