using DAL.Contexts;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditConditions
{
    public class CreditConditionQueryRepository : ModelQueryRepository<CreditConditionModel, CreditConditionDto>, ICreditConditionQueryRepository
    {
        public CreditConditionQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}