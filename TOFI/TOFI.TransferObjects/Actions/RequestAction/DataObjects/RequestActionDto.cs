using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;

namespace TOFI.TransferObjects.Actions.RequestAction.DataObjects
{
    public class RequestActionDto : ActionDto
    {
        public CreditRequestDto CreditRequest { get; set; }
    }
}