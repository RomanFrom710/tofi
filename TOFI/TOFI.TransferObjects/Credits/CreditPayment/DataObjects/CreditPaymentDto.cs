using System;
using TOFI.TransferObjects.Common.Price.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.CreditPayment.DataObjects
{
    public class CreditPaymentDto: ModelDto
    {
        public DateTime Timestamp { get; set; }

        public PriceDto PaymentSum { get; set; }

        public CreditAccountDto CreditAccount { get; set; }

    }
}
