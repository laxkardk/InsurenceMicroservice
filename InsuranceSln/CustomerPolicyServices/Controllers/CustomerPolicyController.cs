using CustomerPolicyServices.Feature.Commands;
using CustomerPolicyServices.Feature.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPolicyServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPolicyController : ControllerBase
    {
        private IMediator _mediator;

        public CustomerPolicyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a New CustomerPolicy.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateCustomerPolicyCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Gets all CustomerPolicy.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCustomerPolicyQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// Gets CustomerPolicy Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var response = await _mediator.Send(new GetCustomerPolicyByIdQuery { Id = id });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
