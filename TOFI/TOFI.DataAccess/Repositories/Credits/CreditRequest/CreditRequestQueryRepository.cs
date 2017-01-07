using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Models.Credits.CreditRequest;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;
using TOFI.TransferObjects.Credits.CreditRequest.Queries;

namespace DAL.Repositories.Credits.CreditRequest
{
    public class CreditRequestQueryRepository : ModelQueryRepository<CreditRequestModel, CreditRequestDto>, ICreditRequestQueryRepository
    {
        public CreditRequestQueryRepository(TofiContext context) : base(context)
        {
        }


        public IEnumerable<CreditRequestDto> Handle(ClientRequestsQuery query)
        {
            return ModelsDao.Where(m => m.Client.Id == query.ClientId).MapTo<CreditRequestDto>();
        }

        public Task<IEnumerable<CreditRequestDto>> HandleAsync(ClientRequestsQuery query)
        {
            return ModelsDao.Where(m => m.Client.Id == query.ClientId).MapToAsync<CreditRequestDto>();
        }

        public IEnumerable<CreditRequestDto> Handle(OperatorRequestsQuery query)
        {
            return ModelsDao.Where(m => m.IsOperatorApproved == null).MapTo<CreditRequestDto>();
        }

        public Task<IEnumerable<CreditRequestDto>> HandleAsync(OperatorRequestsQuery query)
        {
            return ModelsDao.Where(m => m.IsOperatorApproved == null).MapToAsync<CreditRequestDto>();
        }

        public IEnumerable<CreditRequestDto> Handle(SecurityRequestsQuery query)
        {
            return ModelsDao.Where(m => (m.IsOperatorApproved ?? false) && m.IsSecurityApproved == null)
                .MapTo<CreditRequestDto>();
        }

        public Task<IEnumerable<CreditRequestDto>> HandleAsync(SecurityRequestsQuery query)
        {
            return ModelsDao.Where(m => (m.IsOperatorApproved ?? false) && m.IsSecurityApproved == null)
                .MapToAsync<CreditRequestDto>();
        }

        public IEnumerable<CreditRequestDto> Handle(CommiteeRequestsQuery query)
        {
            return ModelsDao.Where(
                m => (m.IsOperatorApproved ?? false) && (m.IsSecurityApproved ?? false) &&
                     m.IsCreditCommitteeApproved == null).MapTo<CreditRequestDto>();
        }

        public Task<IEnumerable<CreditRequestDto>> HandleAsync(CommiteeRequestsQuery query)
        {
            return ModelsDao.Where(
                m => (m.IsOperatorApproved ?? false) && (m.IsSecurityApproved ?? false) &&
                     m.IsCreditCommitteeApproved == null).MapToAsync<CreditRequestDto>();
        }

        public IEnumerable<CreditRequestDto> Handle(DepartmentRequestsQuery query)
        {
            return ModelsDao.Where(
                m => (m.IsOperatorApproved ?? false) && (m.IsSecurityApproved ?? false) &&
                     (m.IsCreditCommitteeApproved ?? false) && m.IsCreditDepartmentApproved == null)
                .MapTo<CreditRequestDto>();
        }

        public Task<IEnumerable<CreditRequestDto>> HandleAsync(DepartmentRequestsQuery query)
        {
            return ModelsDao.Where(
                m => (m.IsOperatorApproved ?? false) && (m.IsSecurityApproved ?? false) &&
                     (m.IsCreditCommitteeApproved ?? false) && m.IsCreditDepartmentApproved == null)
                .MapToAsync<CreditRequestDto>();
        }

        public IEnumerable<CreditRequestDto> Handle(ApprovedRequestsQuery query)
        {
            return ModelsDao.Where(
                m => (m.IsOperatorApproved ?? false) && (m.IsSecurityApproved ?? false) &&
                     (m.IsCreditCommitteeApproved ?? false) && (m.IsCreditDepartmentApproved ?? false))
                .MapTo<CreditRequestDto>();
        }

        public Task<IEnumerable<CreditRequestDto>> HandleAsync(ApprovedRequestsQuery query)
        {
            return ModelsDao.Where(
                m => (m.IsOperatorApproved ?? false) && (m.IsSecurityApproved ?? false) &&
                     (m.IsCreditCommitteeApproved ?? false) && (m.IsCreditDepartmentApproved ?? false))
                .MapToAsync<CreditRequestDto>();
        }

        public IEnumerable<CreditRequestDto> Handle(ApprovedClientRequestsQuery query)
        {
            return ModelsDao.Where(
                    m => (m.IsOperatorApproved ?? false) && (m.IsSecurityApproved ?? false) &&
                         (m.IsCreditCommitteeApproved ?? false) && (m.IsCreditDepartmentApproved ?? false) &&
                         m.Client.Id == query.ClientId)
                .MapTo<CreditRequestDto>();
        }

        public Task<IEnumerable<CreditRequestDto>> HandleAsync(ApprovedClientRequestsQuery query)
        {
            return ModelsDao.Where(
                    m => (m.IsOperatorApproved ?? false) && (m.IsSecurityApproved ?? false) &&
                         (m.IsCreditCommitteeApproved ?? false) && (m.IsCreditDepartmentApproved ?? false) &&
                         m.Client.Id == query.ClientId)
                .MapToAsync<CreditRequestDto>();
        }
    }
}