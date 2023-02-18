using PolicyMasterService.Common;

namespace PolicyMasterService.Models
{
    public class Response<T>
    {
        public Response() => StatusCode = (int)ResponseCodes.Success;

        public int StatusCode { get; set; }

        public string Status { get; set; }

        public ErrorDetails? Error { get; set; }
    }

    public class ErrorDetails
    {
        public string Code { set; get; } = string.Empty;
        public string Message { set; get; } = string.Empty;
    }
}
