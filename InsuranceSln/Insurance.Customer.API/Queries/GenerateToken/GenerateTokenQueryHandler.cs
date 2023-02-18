using Insurance.CustomerAPI.Data;
using Insurance.CustomerAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Insurance.CustomerAPI.Queries.GenerateToken
{
    public class GenerateTokenQueryHandler : IRequestHandler<GenerateTokenQuery, AuthenticationResponse>
    {
        private readonly CustomerDbContext _context;
        private readonly IConfiguration _configuration;
        public GenerateTokenQueryHandler(CustomerDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthenticationResponse> Handle(GenerateTokenQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => request.UserName == request.UserName);

            if(customer == null ||  request.Password != _configuration.GetSection("Password").Value)
            {
                return new AuthenticationResponse();
            }


            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration.GetSection("JWTToken:ExpiryTimeStamp").Value));
            var tokenKey = Encoding.ASCII.GetBytes(_configuration.GetSection("JWTToken:Secretkey").Value);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, request.UserName),
                new Claim("Role", "Customer")
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = request.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token
            };
        }
    }
}
