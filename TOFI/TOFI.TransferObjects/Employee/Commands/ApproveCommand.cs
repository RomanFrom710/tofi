namespace TOFI.TransferObjects.Employee.Commands
{
    public abstract class ApproveCommand : Command
    {
        public int CreditRequestId { get; set; }

        public int EmployeeId { get; set; }

        public bool Approved { get; set; }

        public string Comments { get; set; }
    }
}