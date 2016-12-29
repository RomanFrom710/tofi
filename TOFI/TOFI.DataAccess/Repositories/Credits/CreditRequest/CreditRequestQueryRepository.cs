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
    }
}