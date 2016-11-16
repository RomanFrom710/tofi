using DAL.Repositories.Model;
using TOFI.TransferObjects.Admin.DataObjects;

namespace DAL.Repositories.Admin
{
    public interface IAdminQueryRepository : IModelQueryRepository<AdminDto>
    {
    }
}