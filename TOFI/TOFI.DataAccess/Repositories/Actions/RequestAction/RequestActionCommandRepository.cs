using DAL.Contexts;
using DAL.Models.Actions;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Actions.RequestAction.DataObjects;

namespace DAL.Repositories.Actions.RequestAction
{
    public class RequestActionCommandRepository : ModelCommandRepository<RequestActionModel, RequestActionDto>, IRequestActionCommandRepository
    {
        public RequestActionCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void RestoreFkModels(RequestActionModel model, RequestActionDto modelDto)
        {
            model.Employee = GetEmployeeModel(modelDto.Employee?.Id);
            model.CreditRequest = GetCreditRequestModel(modelDto.CreditRequest?.Id);
        }
    }
}