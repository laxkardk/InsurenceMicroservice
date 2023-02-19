using PolicyMasterService.Common;

namespace PolicyMasterService.Models
{
    /// <summary>
    /// Response entity (generic) to show api response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MediatResponseEntity<T>
    {
        public MediatResponseEntity()
        {
            StatusCode = (int)ResponseCodes.Success;
            Status = Constants.ResponseSuccess;
        }

        public int StatusCode { get; set; }

        public string Status { get; set; }

        public ErrorDetails? Error { get; set; }
    }

    /// <summary>
    /// Error Details 
    /// </summary>
    public class ErrorDetails
    {
        public string Code { set; get; } = string.Empty;
        public string Message { set; get; } = string.Empty;
    }
}
