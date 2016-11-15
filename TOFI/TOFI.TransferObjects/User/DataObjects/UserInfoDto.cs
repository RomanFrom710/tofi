using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.User.DataObjects
{
    public class UserInfoDto : ModelDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public bool EmailConfirmed { get; set; }
    }
}