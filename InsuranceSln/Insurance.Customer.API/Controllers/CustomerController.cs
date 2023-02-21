using Insurance.CustomerAPI.Commands.CreateCustomer;
using Insurance.CustomerAPI.Commands.DeleteCustomer;
using Insurance.CustomerAPI.Queries.GetAllCustomer;
using Insurance.CustomerAPI.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.CustomerAPI.Controllers
{
    /// <summary>
    /// API Controller to Manage Customers
    /// </summary>
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region [Private Properties]

        private readonly IMediator _mediator;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="mediator"></param>
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion [Constructor]

        #region [Public Action Methods]

        /// <summary>
        /// Creates New Customer
        /// </summary>
        /// <param name="customer">Customer Input Data</param>
        /// <returns></returns>
        [HttpPost("customer/create")]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerCommand customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }

        /// <summary>
        /// Updates Customer
        /// </summary>
        /// <param name="customer">Customer Input Data</param>
        /// <returns></returns>
        [HttpPost("customer/update")]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] UpdateCustomerCommand customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }

        /// <summary>
        /// Deletes Customer
        /// </summary>
        /// <param name="customer">Customer Input Data</param>
        /// <returns></returns>

        [HttpPost("customer/delete")]
        public async Task<IActionResult> DeleteCustomerAsync([FromBody] DeleteCustomerCommand customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }

        /// <summary>
        /// Lists Customer
        /// </summary>
        /// <param name="customer">Customer Input Data</param>
        /// <returns></returns>

        [HttpPost("customer/list")]
        public async Task<IActionResult> GetCustomerAsync([FromBody] GetAllCustomerQuery customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }

        /// <summary>
        /// Customer Details
        /// </summary>
        /// <param name="customer">Customer Input Data</param>
        /// <returns></returns>

        [HttpPost("customer/detail")]
        public async Task<IActionResult> GetCustomerByIdAsync([FromBody] GetCustomerByIdQuery customer)
        {
            var command = await _mediator.Send(customer);

            return Ok(command);
        }

        #endregion [Public Action Methods]
    }
}
