using DAL.Contexts;
using DAL.Models.Credits.BankCredits;
using DAL.Models.Credits.BankCredits.CreditCondition;
using DAL.Models.Employee;
using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditConditions
{
    public class CreditConditionQueryRepository : ModelQueryRepository<CreditConditionModel, CreditConditionDTO>, ICreditConditionQueryRepository
    {
        public CreditConditionQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}