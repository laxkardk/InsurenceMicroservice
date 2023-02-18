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

        public PolicyMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllPolicyList")]
        [SwaggerOperation(Summary = "Get All Policies", OperationId = "GetAllPolicyList")]
        public async Task<ActionResult> GetAllPolicyListAsync()
        {
            var command = await _mediator.Send(new GetAllPolicyListQuery());

            return Ok(command);
        }

    }
}
