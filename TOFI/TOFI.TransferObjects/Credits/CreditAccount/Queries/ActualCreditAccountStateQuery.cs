namespace TOFI.TransferObjects.Credits.CreditAccount.Queries
{
    public class ActualCreditAccountStateQuery: Query
    {
        public int? Id { get; set; }

        public string AgreementNumber { get; set; }

        public static ActualCreditAccountStateQuery WithId(int id)
        {
            return new ActualCreditAccountStateQuery { Id = id };
        }

        public static ActualCreditAccountStateQuery WithAgreementNumber(string agreementNumber)
        {
            return new ActualCreditAccountStateQuery { AgreementNumber = agreementNumber };
        }
    }
}
