using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;
using TOFI.TransferObjects.Credits.CreditRequest.Queries;

namespace DAL.Repositories.Credits.CreditRequest
{
    public interface ICreditRequestQueryRepository : IModelQueryRepository<CreditRequestDto>,
        IListQueryRepository<ClientRequestsQuery, CreditRequestDto>,
        IListQueryRepository<OperatorRequestsQuery, CreditRequestDto>,
        IListQueryRepository<SecurityRequestsQuery, CreditRequestDto>,
        IListQueryRepository<CommiteeRequestsQuery, CreditRequestDto>,
        IListQueryRepository<DepartmentRequestsQuery, CreditRequestDto>
    {
    }
}