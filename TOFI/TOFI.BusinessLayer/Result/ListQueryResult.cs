using System.Linq;
using TOFI.TransferObjects;

namespace BLL.Result
{
    public class ListQueryResult<TDto> : ServiceResult<IQueryable<TDto>, ListQueryResult<TDto>>
        where TDto : Dto
    {
        public Query Query { get; protected set; }


        public ListQueryResult(Query query) : this(query, default(IQueryable<TDto>), true)
        {
        }

        public ListQueryResult(Query query, IQueryable<TDto> result) : this(query, result, true)
        {
        }

        public ListQueryResult(Query query, IQueryable<TDto> result, bool executionCompleted)
            : base(result, executionCompleted)
        {
            Query = query;
        }
    }
}