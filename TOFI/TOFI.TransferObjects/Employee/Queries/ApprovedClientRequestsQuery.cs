namespace TOFI.TransferObjects.Employee.Queries
{
    public class ApprovedClientRequestsQuery : CreditRequestsQuery
    {
        public int? ClientId { get; set; }

        public string PassportNumber { get; set; }


        public static ApprovedClientRequestsQuery WithUserId(int clientId)
        {
            return new ApprovedClientRequestsQuery {ClientId = clientId};
        }

        public static ApprovedClientRequestsQuery WithPassportNumber(string passportNumber)
        {
            return new ApprovedClientRequestsQuery {PassportNumber = passportNumber};
        }
    }
}