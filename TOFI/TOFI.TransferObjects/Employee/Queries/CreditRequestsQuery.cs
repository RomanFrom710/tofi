namespace TOFI.TransferObjects.Employee.Queries
{
    public abstract class CreditRequestsQuery : Query
    {
        public int EmployeeId { get; set; }
    }
}