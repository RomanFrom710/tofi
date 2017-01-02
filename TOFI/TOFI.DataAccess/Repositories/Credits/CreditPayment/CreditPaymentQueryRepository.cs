using DAL.Contexts;
using DAL.Models.Credits.CreditPayment;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace DAL.Repositories.Credits.CreditPayment
{
    public class CreditPaymentQueryRepository : ModelQueryRepository<CreditPaymentModel, CreditPaymentDto>, ICreditPaymentQueryRepository
    {
        public CreditPaymentQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}