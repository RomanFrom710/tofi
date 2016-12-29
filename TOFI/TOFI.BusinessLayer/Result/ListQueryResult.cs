using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TOFI.TransferObjects;

namespace BLL.Result
{
    public class ListQueryResult<T> : ValueResult<IEnumerable<T>, ListQueryResult<T>>
    {
        public Query Query { get; protected set; }


        public ListQueryResult(Query query) : this(query, default(IEnumerable<T>), true)
        {
        }

        public ListQueryResult(Query query, IEnumerable<T> value) : this(query, value, true)
        {
        }

        public ListQueryResult(Query query, IEnumerable<T> value, bool executionCompleted)
            : base(value, executionCompleted)
        {
            Query = query;
        }


        public ListQueryResult<TNew> MapTo<TNew>()
        {
            return new ListQueryResult<TNew>(Query, Value?.Select(arg => Mapper.Map<TNew>(arg)),
                ExecutionComleted) {Message = Message, Exception = Exception, Severity = Severity};
        }
    }
}