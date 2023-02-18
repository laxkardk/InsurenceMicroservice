using Insurance.CustomerAPI.Models;
using MediatR;

namespace Insurance.CustomerAPI.Queries.GenerateToken
{
    /// <summary>
    /// Generate Token Query
    /// </summary>
    public class GenerateTokenQuery : IRequest<AuthenticationResponse>
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
