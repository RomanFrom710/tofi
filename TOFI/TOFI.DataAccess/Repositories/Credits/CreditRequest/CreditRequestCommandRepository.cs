using System;
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


        protected override void RestoreFkModels(CreditRequestModel model)
        {
            RestoreClientModel(model);
            RestoreCreditTypeModel(model);
            RestoreSecurityApprovedModel(model);
            RestoreCreditCommitteeApprovedModel(model);
            RestoreCreditDepartmentApprovedModel(model);
            RestoreCashierApprovedModel(model);
        }

        private void RestoreClientModel(CreditRequestModel model)
        {
            if (model.Client?.Id == null)
            {
                throw new ArgumentException("Client Id is invalid");
            }
            var client = Context.Clients.Find(model.Client.Id);
            if (client == null)
            {
                throw new ArgumentException("Client with given Id doesn't exists");
            }
            model.Client = client;
        }

        private void RestoreCreditTypeModel(CreditRequestModel model)
        {
            if (model.CreditType?.Id == null)
            {
                throw new ArgumentException("CreditType Id is invalid");
            }
            var creditType = Context.CreditTypes.Find(model.CreditType.Id);
            if (creditType == null)
            {
                throw new ArgumentException("CreditType with given Id doesn't exists");
            }
            model.CreditType = creditType;
        }

        private void RestoreSecurityApprovedModel(CreditRequestModel model)
        {
            if (model.SecurityApproved?.Id == null)
            {
                return;
            }
            var employee = Context.Employees.Find(model.SecurityApproved.Id);
            if (employee == null)
            {
                throw new ArgumentException("SecurityApproved with given Id doesn't exists");
            }
            model.SecurityApproved = employee;
        }

        private void RestoreCreditCommitteeApprovedModel(CreditRequestModel model)
        {
            if (model.CreditCommitteeApproved?.Id == null)
            {
                return;
            }
            var employee = Context.Employees.Find(model.CreditCommitteeApproved.Id);
            if (employee == null)
            {
                throw new ArgumentException("CreditCommitteeApproved with given Id doesn't exists");
            }
            model.CreditCommitteeApproved = employee;
        }

        private void RestoreCreditDepartmentApprovedModel(CreditRequestModel model)
        {
            if (model.CreditDepartmentApproved?.Id == null)
            {
                return;
            }
            var employee = Context.Employees.Find(model.CreditDepartmentApproved.Id);
            if (employee == null)
            {
                throw new ArgumentException("CreditDepartmentApproved with given Id doesn't exists");
            }
            model.CreditDepartmentApproved = employee;
        }

        private void RestoreCashierApprovedModel(CreditRequestModel model)
        {
            if (model.CashierApproved?.Id == null)
            {
                return;
            }
            var employee = Context.Employees.Find(model.CashierApproved.Id);
            if (employee == null)
            {
                throw new ArgumentException("CashierApproved with given Id doesn't exists");
            }
            model.CashierApproved = employee;
        }
    }
}