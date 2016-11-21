using BLL.Services.Admin.ViewModels;
using BLL.Services.User;
using TOFI.TransferObjects.Admin.DataObjects;

namespace BLL.Services.Admin
{
    public interface IAdminService : IUserService<AdminDto, AdminViewModel>
    {
    }
}