using System;
using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Credits.CreditPayment.ViewModels
{
    public class CreditPaymentViewModel : ModelViewModel
    {
        public DateTime Timestamp { get; set; }

        public PriceViewModel PaymentSum { get; set; }

        public CreditAccountViewModel CreditAccount { get; set; }
    }
}