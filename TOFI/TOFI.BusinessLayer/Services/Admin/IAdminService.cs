using BLL.Services.Admin.ViewModels;
using BLL.Services.User;

namespace BLL.Services.Admin
{
    public interface IAdminService : IUserService<AdminViewModel>
    {
    }
}