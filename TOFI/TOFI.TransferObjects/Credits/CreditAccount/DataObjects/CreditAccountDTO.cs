using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Common.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;
using TOFI.TransferObjects.User.DataObjects;

namespace TOFI.TransferObjects.Credits.CreditAccount.DataObjects
{
    public class CreditAccountDTO: ModelDto
    {
        public string CreditAgreementNumber { get; set; }

        public PriceDTO TotalDebt { get; set; }

        public PriceDTO FinesForOverdue { get; set; }

        public double Persent { get; set; }

        public PriceDTO RemainDebt { get; set; }

        public UserDto User { get; set; }

        public BankCreditDTO BankCredit { get; set; }
    }
}
