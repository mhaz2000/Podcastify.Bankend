using Newtonsoft.Json;

namespace Podcastify.API.Helpers.ExceptionHandlers.Exceptions
{
    public class BaseException
    {
        public BaseException(string message)
        {
            Message = message;
        }
        public BaseException(string message, string stackTrace)
        {
            Message = message;
            StackTrace = stackTrace;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
