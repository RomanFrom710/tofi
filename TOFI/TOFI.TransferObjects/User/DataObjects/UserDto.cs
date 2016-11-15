using TOFI.TransferObjects.Auth.DataObjects;

namespace TOFI.TransferObjects.User.DataObjects
{
    public class UserDto : AuthDto
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}