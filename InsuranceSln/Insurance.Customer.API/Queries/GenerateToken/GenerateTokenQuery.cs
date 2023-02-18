using Insurance.CustomerAPI.Models;
using MediatR;

namespace Insurance.CustomerAPI.Queries.GenerateToken
{
    public class GenerateTokenQuery : IRequest<AuthenticationResponse>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
