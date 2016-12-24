using TOFI.TransferObjects.Auth.DataObjects;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.User.DataObjects
{
    public class UserDto : ModelDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public AuthDto Auth { get; set; }

        public ClientDto Client { get; set; }

        public EmployeeDto Employee { get; set; }
    }
}