using DAL.Contexts;
using DAL.Models.Credits.BankCredits.CreditTypes;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditTypes
{
    public class CreditTypeQueryRepository : ModelQueryRepository<CreditTypeModel, CreditTypeDto>, ICreditTypeQueryRepository
    {
        public CreditTypeQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}