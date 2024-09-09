namespace Utility.Response
{
    public class ServiceException
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public ServiceException()
        {

        }
        public ServiceException(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
