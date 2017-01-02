using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace DAL.Repositories.Credits.CreditPayment
{
    public interface ICreditPaymentQueryRepository : IModelQueryRepository<CreditPaymentDto>
    {
    }
}