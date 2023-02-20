using CustomerPolicyServices.Common;

namespace CustomerPolicyServices.Models
{
    /// <summary>
    /// Response Model
    /// </summary>
    /// <typeparam name="T">Object Type</typeparam>
    public class Response<T>
    {
        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        public Response()
        {
            Status = (int)Constant.Status_Fail_Code;
            StatusName = Constant.Status_Fail.ToString();
        }

        #endregion [Constructor]

        #region [Private Properties]

        /// <summary>
        /// Status Code
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Status Name Success, Failed, etc..
        /// </summary>

        public string StatusName { get; set; }

        /// <summary>
        /// Template type Data
        /// </summary>
        public T? Data { set; get; }

        /// <summary>
        /// Error Details
        /// </summary>
        public ErrorDetail? Error { get; set; }

        #endregion [Private Properties]

        #region [Public Methods]

        /// <summary>
        /// Set Sucess Response details
        /// </summary>
        /// <param name="data"></param>
        public void SetSuccess(T data)
        {

            Status = (int)Constant.Status_Success_Code;
            StatusName = Constant.Status_Success.ToString();
            Data = data;
        }

        /// <summary>
        /// Set Error Details
        /// </summary>
        /// <param name="message"></param>
        public void SetError(string message)
        {
            Error = new ErrorDetail()
            {
                Message = message
            };
        }

        #endregion [Public Methods]
    }

    /// <summary>
    /// Error Detail Model
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// Error Message
        /// </summary>
        public string Message { set; get; } = string.Empty;
    }
}
