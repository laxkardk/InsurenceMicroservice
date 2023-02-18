namespace Insurance.CustomerAPI.Models
{
    /// <summary>
    /// Authentication Input request
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
