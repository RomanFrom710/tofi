using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Auth.DataObjects
{
    public class AuthDto : ModelDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}