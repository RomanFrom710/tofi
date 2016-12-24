using DAL.Contexts;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditRequirements
{
    public class CreditRequirementCommandRepository : ModelCommandRepository<CreditRequirementModel, CreditRequirementDTO>, ICreditRequirementCommandRepository
    {
        public CreditRequirementCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}