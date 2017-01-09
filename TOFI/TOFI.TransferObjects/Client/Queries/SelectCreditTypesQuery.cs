namespace TOFI.TransferObjects.Client.Queries
{
    public class SelectCreditTypesQuery : Query
    {
        public int MonthDuration { get; set; }

        public decimal CreditSumValue { get; set; }

        public decimal CreditSumCurrencyId { get; set; }

        public string CreditPurpose { get; set; }
    }
}