using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditRequirements
{
    public interface ICreditRequirementQueryRepository : IModelQueryRepository<CreditRequirementDTO>
    {
    }
}