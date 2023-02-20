using MediatR;
using Microsoft.AspNetCore.Mvc;
using PolicyMasterService.Commands;
using PolicyMasterService.Common;
using PolicyMasterService.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace PolicyMasterService.Controllers
{
    [Route("api/[action]")]
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

        #region Methods

        /// <summary>
        /// Get all policies from database
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get specific policy details from database
        /// </summary>
        /// <param name="getPolicyDetailsQuery">Policy Id to get details</param>
        /// <returns></returns>
        [HttpPost(Name = "GetPolicyDetails")]
        [SwaggerOperation(Summary = "Get specific policy details", OperationId = "GetPolicyDetails")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPolicyDetailsAsync(GetPolicyDetailsQuery getPolicyDetailsQuery)
        {
            try
            {
                var command = await _mediator.Send(getPolicyDetailsQuery);

                // if policy id not found
                if (command == null)
                    return StatusCode(StatusCodes.Status400BadRequest, Constants.ResponseNotFound);

                return Ok(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Add new policy
        /// </summary>
        /// <param name="addPolicyCmd">Policy details</param>
        /// <returns></returns>
        [HttpPost(Name = "AddPolicy")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Add Policy", OperationId = "AddPolicy")]
        public async Task<IActionResult> AddPolicyAsync(AddPolicyCmd addPolicyCmd)
        {
            try
            {
                var command = await _mediator.Send(addPolicyCmd);
                return StatusCode(StatusCodes.Status201Created, Constants.ResponseAdd);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        /// <summary>
        /// Update existing policy
        /// </summary>
        /// <param name="updatePolicyCmd">Policy details</param>
        /// <returns></returns>
        [HttpPost(Name = "UpdatePolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Update Policy", OperationId = "UpdatePolicy")]
        public async Task<IActionResult> UpdatePolicyAsync(UpdatePolicyCmd updatePolicyCmd)
        {
            try
            {
                var command = await _mediator.Send(updatePolicyCmd);

                // if policy id not found
                if (command.StatusCode == (int)ResponseCodes.NotFound)
                    return StatusCode(StatusCodes.Status400BadRequest, Constants.ResponseNotFound);

                return StatusCode(StatusCodes.Status200OK, Constants.ResponseUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Delete Policy
        /// </summary>
        /// <param name="deletePolicyCmd">Policy Id</param>
        /// <returns></returns>
        [HttpPost(Name = "DeletePolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Delete Policy", OperationId = "DeletePolicy")]
        public async Task<IActionResult> DeletePolicyAsync(DeletePolicyCmd deletePolicyCmd)
        {
            try
            {
                var command = await _mediator.Send(deletePolicyCmd);

                // if policy id not found
                if (command.StatusCode == (int)ResponseCodes.NotFound)
                    return StatusCode(StatusCodes.Status400BadRequest, Constants.ResponseNotFound);

                return StatusCode(StatusCodes.Status200OK, Constants.ResponseDelete);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        #endregion Methods

    }
}
