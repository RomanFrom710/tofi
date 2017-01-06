using Microsoft.AspNet.Identity;

namespace TOFI.Web.Auth
{
    public class UserRole : IRole
    {
        public string Id => Name;

        public string Name { get; set; }
    }
}