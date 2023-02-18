using Insurance.CustomerAPI.Models;
using Insurance.CustomerAPI.Queries.GenerateToken;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] GenerateTokenQuery authenticationRequest)
        {
            var authenticationResponse = await _mediator.Send(authenticationRequest);
            if (authenticationResponse == null) return Unauthorized();
            return Ok(authenticationResponse);
        }
    }
}
