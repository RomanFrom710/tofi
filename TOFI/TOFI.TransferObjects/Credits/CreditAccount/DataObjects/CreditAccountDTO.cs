using System;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Common.Currency.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.CreditAccount.DataObjects
{
    public class CreditAccountDto : ModelDto
    {
        public string CreditAgreementNumber { get; set; }

        public string Description { get; set; }

        public DateTime AgreementDate { get; set; }

        public int TotalMonthDuration { get; set; }

        public CurrencyDto Currency { get; set; }

        public ClientDto Client { get; set; }

        public CreditTypeDto CreditType { get; set; }
    }
}