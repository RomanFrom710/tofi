using BLL.Services.Admin.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Admin;
using TOFI.TransferObjects.Admin.DataObjects;

namespace BLL.Services.Admin
{
    public class AdminService : ModelService<AdminDto, AdminViewModel>, IAdminService
    {
        private readonly IAdminQueryRepository _queryRepository;
        private readonly IAdminCommandRepository _commandRepository;


        public AdminService(IAdminQueryRepository queryRepository,
            IAdminCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}