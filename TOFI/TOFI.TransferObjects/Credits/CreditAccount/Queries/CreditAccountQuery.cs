namespace TOFI.TransferObjects.Credits.CreditAccount.Queries
{
    public class CreditAccountQuery : Query
    {
        public int? Id { get; set; }

        public string AgreementNumber { get; set; }


        public static CreditAccountQuery WithId(int id)
        {
            return new CreditAccountQuery {Id = id};
        }

        public static CreditAccountQuery WithAgreementNumber(string agreementNumber)
        {
            return new CreditAccountQuery {AgreementNumber = agreementNumber};
        }
    }
}