using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.BankCredit
{
    public interface IBankCreditQueryRepository : IModelQueryRepository<BankCreditDto>
    {
    }
}