using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;

namespace BLL.Services.Credits.CreditRequest
{
    public interface ICreditRequestService : IModelService<CreditRequestDto, CreditRequestViewModel>
    {
    }
}