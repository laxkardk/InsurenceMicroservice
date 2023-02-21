namespace Insurance.CustomerAPI.Models
{
    /// <summary>
    /// Authentication Response with generated token
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// JWT Token
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Expires In Minutes
        /// </summary>
        public int ExpiresIn { get; set; }
    }
}
