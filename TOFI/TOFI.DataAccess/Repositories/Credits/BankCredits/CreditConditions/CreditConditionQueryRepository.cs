using DAL.Contexts;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditConditions
{
    public class CreditConditionQueryRepository : ModelQueryRepository<CreditConditionModel, CreditConditionDTO>, ICreditConditionQueryRepository
    {
        public CreditConditionQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}