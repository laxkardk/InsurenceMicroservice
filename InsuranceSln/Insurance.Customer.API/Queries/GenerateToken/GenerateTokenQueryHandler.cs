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
    /// <summary>
    /// Generate Token Query Handler
    /// </summary>
    public class GenerateTokenQueryHandler : IRequestHandler<GenerateTokenQuery, AuthenticationResponse>
    {
        #region [Private Properties]

        private readonly CustomerDbContext _context;
        private readonly IConfiguration _configuration;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="context">Customer Database Context</param>
        /// <param name="configuration">Configuration</param>
        public GenerateTokenQueryHandler(CustomerDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        #endregion [Constructor]

        #region [Public Methods]

        /// <summary>
        /// Generate token handles
        /// </summary>
        /// <param name="request">Generate Token Request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        public async Task<AuthenticationResponse> Handle(GenerateTokenQuery request, CancellationToken cancellationToken)
        {
            // Searching First or default record
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => request.UserName == request.UserName);

            // if Password didn't matched returning empty token response
            if(customer == null ||  request.Password != _configuration.GetSection("Password").Value)
            {
                return new AuthenticationResponse();
            }

            // Token Expiration time
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration.GetSection("JWTToken:ExpiryTimeStamp").Value));
            // Secret Key
            var tokenKey = Encoding.ASCII.GetBytes(_configuration.GetSection("JWTToken:Secretkey").Value);
            // Claim Indenty
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, request.UserName),
                new Claim("Role", "Customer")
            });

            // Signed Credentials to generate token
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            // Securty Token Descriptor
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            // Token Handler
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            // Generates JWt Token
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            // Gets jwt token
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            // returning reponsed with JWT token
            return new AuthenticationResponse
            {
                UserName = request.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                Token = token
            };
        }

        #endregion [Public Methods]
    }
}
