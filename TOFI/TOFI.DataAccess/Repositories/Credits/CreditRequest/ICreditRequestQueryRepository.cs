using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;

namespace DAL.Repositories.Credits.CreditRequest
{
    public interface ICreditRequestQueryRepository : IModelQueryRepository<CreditRequestDto>
    {
    }
}