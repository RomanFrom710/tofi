using DAL.Contexts;
using DAL.Models.Credits.BankCredits.CreditTypes;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditTypes
{
    public class CreditTypeCommandRepository : ModelCommandRepository<CreditTypeModel, CreditTypeDto>, ICreditTypeCommandRepository
    {
        public CreditTypeCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}