using BLL.Services.Admin.ViewModels;
using BLL.Services.User;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Admin.DataObjects;

namespace BLL.Services.Admin
{
    public class AdminService : UserService<AdminDto, AdminViewModel>, IAdminService
    {
        public AdminService(IModelQueryRepository<AdminDto> queryRepository,
            IModelCommandRepository<AdminDto> commandRepository) : base(queryRepository, commandRepository)
        {
        }
    }
}