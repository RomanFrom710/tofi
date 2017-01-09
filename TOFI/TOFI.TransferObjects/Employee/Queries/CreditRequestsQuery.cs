namespace TOFI.TransferObjects.Employee.Queries
{
    public abstract class CreditRequestsQuery : Query
    {
        public int EmployeeId { get; set; }

        public int? CreditTypeId { get; set; }

        public int? CreditSumCurrencyId { get; set; }

        public decimal? MinCreditSumValue { get; set; }
    }
}