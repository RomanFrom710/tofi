using DAL.Contexts;
using DAL.Models.Credits.BankCredits;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Employee;
using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditRequirements
{
    public class CreditRequirementCommandRepository : ModelCommandRepository<CreditRequirementModel, CreditRequirementDTO>, ICreditRequirementCommandRepository
    {
        public CreditRequirementCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}