namespace TOFI.TransferObjects.Employee.Commands
{
    public class OpenCreditAccountCommand : Command
    {
        public int EmployeeId { get; set; }

        public int CreditRequestId { get; set; }
    }
}