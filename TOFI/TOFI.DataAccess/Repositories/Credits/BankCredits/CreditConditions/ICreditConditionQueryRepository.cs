using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditConditions
{
    public interface ICreditConditionQueryRepository : IModelQueryRepository<CreditConditionDTO>
    {
    }
}