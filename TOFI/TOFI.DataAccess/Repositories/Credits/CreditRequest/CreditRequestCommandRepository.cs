using DAL.Contexts;
using DAL.Models.Credits.CreditRequest;
using DAL.Repositories.Credits.CreditRequest;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;

namespace DAL.Repositories.Credits.CreditAccount
{
    public class CreditRequestCommandRepository : ModelCommandRepository<CreditRequestModel, CreditRequestDto>, ICreditRequestCommandRepository
    {
        public CreditRequestCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}