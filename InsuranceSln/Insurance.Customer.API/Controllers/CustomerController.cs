using Insurance.CustomerAPI.Commands.CreateCustomer;
using Insurance.CustomerAPI.Commands.DeleteCustomer;
using Insurance.CustomerAPI.Queries.GetAllCustomer;
using Insurance.CustomerAPI.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.CustomerAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("customer/create")]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerCommand customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }

        [HttpPost("customer/update")]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] UpdateCustomerCommand customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }

        [HttpPost("customer/delete")]
        public async Task<IActionResult> DeleteCustomerAsync([FromBody] DeleteCustomerCommand customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }

        [HttpPost("customer/list")]
        public async Task<IActionResult> GetCustomerAsync([FromBody] GetAllCustomerQuery customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }

        [HttpPost("customer/detail")]
        public async Task<IActionResult> GetCustomerByIdAsync([FromBody] GetCustomerByIdQuery customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }
    }
}
