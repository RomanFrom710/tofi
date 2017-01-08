using BLL.Services.Client.ViewModels;
using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Model.ViewModels;
using System;

namespace BLL.Services.Credits.CreditAccount.ViewModels
{
    public class CreditAccountViewModel : ModelViewModel
    {
        public string CreditAgreementNumber { get; set; }
        
        public string Description { get; set; }

        public DateTime AgreementDate { get; set; }

        public int TotalMonthDuration { get; set; }

        public CurrencyViewModel Currency { get; set; }

        public ClientViewModel Client { get; set; }

        public CreditTypeViewModel CreditType { get; set; }

        public CreditRequestViewModel CreditRequest { get; set; }
    }
}