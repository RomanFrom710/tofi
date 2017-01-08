using TOFI.TransferObjects.Common.Price.DataObjects;

namespace TOFI.TransferObjects.Employee.Commands
{
    public class AddPaymentCommand : Command
    {
        public int CreditAccountId { get; set; }

        public int EmployeeId { get; set; }

        public PriceDto PaymentSum { get; set; }
    }
}