using DAL.Contexts;
using DAL.Models.Credits.CreditRequest;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;

namespace DAL.Repositories.Credits.CreditRequest
{
    public class CreditRequestCommandRepository : ModelCommandRepository<CreditRequestModel, CreditRequestDto>, ICreditRequestCommandRepository
    {
        public CreditRequestCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void RestoreFkModels(CreditRequestModel model, CreditRequestDto modelDto)
        {
            model.CreditSum.Currency = GetCurrencyModel(modelDto.CreditSum.Currency?.Id);
            model.Client = GetClientModel(modelDto.Client?.Id);
            model.CreditType = GetCreditTypeModel(modelDto.CreditType?.Id);
            model.OperatorApproved = GetEmployeeModelOptional(modelDto.OperatorApproved?.Id);
            model.SecurityApproved = GetEmployeeModelOptional(modelDto.SecurityApproved?.Id);
            model.CreditCommitteeApproved = GetEmployeeModelOptional(modelDto.CreditCommitteeApproved?.Id);
            model.CreditDepartmentApproved = GetEmployeeModelOptional(modelDto.CreditDepartmentApproved?.Id);
            model.RequestOpener = GetEmployeeModelOptional(modelDto.RequestOpener?.Id);
            model.LatestEmployeeHandledBy = GetEmployeeModelOptional(modelDto.LatestEmployeeHandledBy?.Id);
        }
    }
}