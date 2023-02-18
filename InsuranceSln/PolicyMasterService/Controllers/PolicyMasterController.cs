using MediatR;
using Microsoft.AspNetCore.Mvc;
using PolicyMasterService.Queries;
using PolicyMasterService.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace PolicyMasterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PolicyMasterController> _logger;

        public PolicyMasterController(IMediator mediator, ILogger<PolicyMasterController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllPolicyList")]
        [SwaggerOperation(Summary = "Get All Policies", OperationId = "GetAllPolicyList")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllPolicyListAsync()
        {
            try
            {
                var command = await _mediator.Send(new GetAllPolicyListQuery());
                return Ok(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
