using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Model.ViewModels;
using BLL.Services.User.ViewModels;
using System;

namespace BLL.Services.Credits.CreditAccount.ViewModels
{
    public class CreditAccountViewModel : ModelViewModel
    {
        public string CreditAgreementNumber { get; set; }
        
        public string Description { get; set; }

        public DateTime AgreementDate { get; set; }

        public CurrencyViewModel Currency { get; set; }

        public int TotalMonthDuration { get; set; }

        public UserViewModel User { get; set; }

        public CreditTypeViewModel CreditType { get; set; }
    }
}