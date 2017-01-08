using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;

namespace TOFI.TransferObjects.Credits.CreditAccount.Commands
{
    public class OpenAccountCommand : Command
    {
        public CreditRequestDto Request { get; set; }
    }
}