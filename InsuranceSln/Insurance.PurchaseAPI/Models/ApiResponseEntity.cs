using Insurance.PurchaseAPI.Utility;

namespace Insurance.PurchaseAPI.Models
{
    public class ApiResponseEntity<T>
    {
        public ApiResponseEntity()
        {
            Status = MsgConstant.ResponseSuccess;
        }


        public string Status { get; set; }

        public ErrorDetails? Error { get; set; }
    }

    public class ErrorDetails
    {
        public string Code { set; get; } = string.Empty;
        public string Message { set; get; } = string.Empty;
    }

}
