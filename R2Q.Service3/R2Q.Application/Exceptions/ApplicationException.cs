using System.Runtime.Serialization;

namespace R2Q.Application.Exceptions
{
    [Serializable]
    public class ApplicationException : Exception
    {
        public ApplicationException()
        { }

        public ApplicationException(string message) : base(message)
        { }

        public ApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
            ExceptionMessage = message;
        }

        public ApplicationException(int code, string message)
            : base(message)
        {
            ExceptionCode = code;
            ExceptionMessage = message;
        }

        public ApplicationException(int code, string message, Exception innerException)
            : base(message, innerException)
        {
            ExceptionCode = code;
            ExceptionMessage = message;
        }

        public ApplicationException(ExceptionCode code, string message)
            : base(message)
        {
            ExceptionCode = (int)code;
            ExceptionMessage = message;
        }

        public ApplicationException(ExceptionCode code, string message, Exception innerException)
            : base(message, innerException)
        {
            ExceptionCode = (int)code;
            ExceptionMessage = message;
        }

        public ApplicationException(ExceptionCode code, string message, List<string> messageParameters)
            : base(message)
        {
            ExceptionCode = (int)code;
            ExceptionMessage = message;
            ExceptionMessageParameters = messageParameters;
        }

        protected ApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ExceptionCode = info.GetInt32("ExceptionCode");
            ExceptionMessage = info.GetString("ExceptionMessage");
        }

        public int ExceptionCode { get; set; }

        public string ExceptionMessage { get; set; }

        public List<string> ExceptionMessageParameters { get; set; }
    }

    public enum ExceptionCode
    {
        BadRequest = 400,
        UnauthorizedAccess = 401,
        NotFound = 404,
        InternalServerError = 500
    }
}
