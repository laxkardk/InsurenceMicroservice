namespace PolicyMasterService.Common
{
    /// <summary>
    /// List of all constants
    /// </summary>
    public class Constants
    {
        public const string ResponseSuccess = "Success";

        public const string ResponseFailure = "Failed";

        public const string ResponseNotFound = "Policy Not found";

        public const string ResponseAdd = "New Policy Added";

        public const string ResponseUpdate = "Policy details are updated";

        public const string ResponseDelete = "Policy deleted";
    }

    /// <summary>
    /// Enum to show api responses
    /// </summary>
    public enum ResponseCodes
    {
        /// <summary>
        /// Success
        /// </summary>
        Success = 1,
        /// <summary>
        /// Failed
        /// </summary>
        Failed = 0,
        /// <summary>
        /// Not found
        /// </summary>
        NotFound = 2
    }

}
