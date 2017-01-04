using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace DAL.Repositories.Credits.CreditAccount
{
    public interface ICreditAccountQueryRepository : IModelQueryRepository<CreditAccountDto>,
        IListQueryRepository<CreditPaymentsQuery, CreditPaymentDto>
    {
    }
}