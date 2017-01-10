namespace TOFI.TransferObjects.Credits.CreditAccount.Queries
{
    public class CreditAccountsQuery : Query
    {
        public int? ClientId { get; set; }

        public string PassportNumber { get; set; }
    }
}