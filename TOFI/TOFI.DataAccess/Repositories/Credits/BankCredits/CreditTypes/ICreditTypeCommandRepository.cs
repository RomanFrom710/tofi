using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditTypes
{
    public interface ICreditTypeCommandRepository : IModelCommandRepository<CreditTypeDTO>
    {
    }
}