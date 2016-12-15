using DAL.Contexts;
using DAL.Models.Credits.BankCredits;
using DAL.Models.Credits.BankCredits.CreditType;
using DAL.Models.Employee;
using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditTypes
{
    public class CreditTypeQueryRepository : ModelQueryRepository<CreditTypeModel, CreditTypeDTO>, ICreditTypeQueryRepository
    {
        public CreditTypeQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}