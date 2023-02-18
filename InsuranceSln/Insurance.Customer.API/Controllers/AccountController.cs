using Insurance.CustomerAPI.Models;
using Insurance.CustomerAPI.Queries.GenerateToken;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.CustomerAPI.Controllers
{
    /// <summary>
    /// Account Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region [Private Properties]

        private readonly IMediator _mediator;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="mediator"></param>
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion [Constructor]

        #region [Public Action Methods]

        /// <summary>
        /// Authenticate API action
        /// </summary>
        /// <param name="authenticationRequest">Authenticationinput Request</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] GenerateTokenQuery authenticationRequest)
        {
            var authenticationResponse = await _mediator.Send(authenticationRequest);
            if (authenticationResponse == null) return Unauthorized();
            return Ok(authenticationResponse);
        }

        #endregion [Public Action Methods]
    }
}
