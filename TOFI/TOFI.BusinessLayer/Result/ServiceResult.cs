using System;

namespace BLL.Result
{
    public enum SeverityLevel
    {
        Info = 0,
        Warning = 1, 
        Error = 2,
        Fatal = 3
    }


    public abstract class ServiceResult<TThis> where TThis : ServiceResult<TThis>
    {
        public bool ExecutionComleted { get; protected set; }

        public string Message { get; set; }

        public SeverityLevel? Severity { get; set; }

        public Exception Exception { get; set; }


        protected ServiceResult() : this(true)
        {
        }

        protected ServiceResult(bool executionCompleted)
        {
            ExecutionComleted = executionCompleted;
            Message = null;
            Severity = null;
            Exception = null;
        }


        public TThis Info(string message, Exception exception = null)
        {
            return SetState(SeverityLevel.Info, message, exception);
        }

        public TThis Warning(string message, Exception exception = null)
        {
            return SetState(SeverityLevel.Warning, message, exception);
        }

        public TThis Error(string message, Exception exception = null)
        {
            return SetState(SeverityLevel.Error, message, exception);
        }

        public TThis Fatal(string message, Exception exception = null)
        {
            return SetState(SeverityLevel.Fatal, message, exception);
        }


        private TThis SetState(SeverityLevel severity, string message, Exception exception)
        {
            Severity = severity;
            Message = message;
            Exception = exception;
            return (TThis) this;
        }
    }


    public class ServiceResult : ServiceResult<ServiceResult>
    {
        public ServiceResult() : this(true)
        {
        }

        public ServiceResult(bool executionCompleted) : base(executionCompleted)
        {
        }
    }


    public abstract class ServiceResult<TVal, TThis> : ServiceResult<TThis>
        where TThis : ServiceResult<TThis>
    {
        public TVal Value { get; protected set; }


        protected ServiceResult() : this(default(TVal), true)
        {
        }

        protected ServiceResult(TVal value) : this(value, true)
        {
        }

        protected ServiceResult(TVal value, bool executionCompleted) : base(executionCompleted)
        {
            Value = value;
        }
    }
}