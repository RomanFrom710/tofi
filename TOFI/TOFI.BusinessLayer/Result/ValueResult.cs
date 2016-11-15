namespace BLL.Result
{
    public class ValueResult<TVal> : ServiceResult<ValueResult<TVal>>
    {
        public TVal Value { get; protected set; }


        public ValueResult() : this(default(TVal), true)
        {
        }

        public ValueResult(TVal value) : this(value, true)
        {
        }

        public ValueResult(TVal value, bool executionCompleted) : base(executionCompleted)
        {
            Value = value;
        }
    }
}