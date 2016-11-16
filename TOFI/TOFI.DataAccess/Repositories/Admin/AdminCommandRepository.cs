using DAL.Contexts;
using DAL.Models.Admin;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Admin.DataObjects;

namespace DAL.Repositories.Admin
{
    public class AdminCommandRepository : ModelCommandRepository<AdminModel, AdminDto>, IAdminCommandRepository
    {
        public AdminCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}