using BLL.Services.Credits.CreditRequest.ViewModels;

namespace BLL.Services.Actions.RequestAction.ViewModels
{
    public class RequestActionViewModel : ActionViewModel
    {
        public CreditRequestViewModel CreditRequest { get; set; }
    }
}