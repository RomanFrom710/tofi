using TOFI.TransferObjects;

namespace BLL.Result
{
    public class QueryResult<TDto> : ServiceResult<TDto, QueryResult<TDto>>
        where TDto : Dto
    {
        public Query Query { get; protected set; }


        public QueryResult(Query query) : this(query, default(TDto), true)
        {
        }

        public QueryResult(Query query, TDto result) : this(query, result, true)
        {
        }

        public QueryResult(Query query, TDto result, bool executionCompleted) : base(result, executionCompleted)
        {
            Query = query;
        }
    }
}