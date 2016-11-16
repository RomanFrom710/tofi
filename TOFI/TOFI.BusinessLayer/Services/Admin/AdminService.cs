using BLL.Services.Admin.ViewModels;
using BLL.Services.User;
using DAL.Repositories.Admin;
using TOFI.TransferObjects.Admin.DataObjects;

namespace BLL.Services.Admin
{
    public class AdminService : UserService<AdminDto, AdminViewModel>, IAdminService
    {
        public AdminService(IAdminQueryRepository queryRepository,
            IAdminCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
        }
    }
}