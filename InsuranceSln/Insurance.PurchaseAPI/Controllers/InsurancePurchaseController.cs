using Insurance.PurchaseAPI.CQRS.Queries.Interfaces;
using Insurance.PurchaseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.PurchaseAPI.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InsurancePurchaseController : Controller
    {
        private readonly IInsurancePurchaseCommand _insurancePurchaseCommand;
        private readonly ILogger<InsurancePurchaseController> _logger;

        public InsurancePurchaseController(IInsurancePurchaseCommand insurancePurchaseCommand, ILogger<InsurancePurchaseController> logger)
        {
            _insurancePurchaseCommand = insurancePurchaseCommand;
            _logger = logger;
        }
        /// <summary>
        /// Method for purchasing policy
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost (Name = "PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(InsuranceProductCommandModel model)
        {
            try
            {
                var insurancePolicy = await _insurancePurchaseCommand.PlaceOrder(model);
                return StatusCode(StatusCodes.Status201Created, insurancePolicy);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Update to an existing policy
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(Name = "UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(InsuranceProductCommandModel model)
        {
            try
            {
                var product = await _insurancePurchaseCommand.UpdateOrder(model);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Delete an existing policy
        /// </summary>
        /// <param name="customerPolicyId"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int customerPolicyId)
        {
            try
            {
                var policy = await _insurancePurchaseCommand.DeleteOrder(customerPolicyId);
                return StatusCode(StatusCodes.Status201Created, policy);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Confirn an policy purchase
        /// </summary>
        /// <param name="customerPolicyId"></param>
        /// <returns></returns>
        [HttpPost(Name = "ConfirmOrder")]
        public async Task<IActionResult> ConfirmOrder(int customerPolicyId)
        {
            try
            {
                var product = await _insurancePurchaseCommand.ConfirmOrder(customerPolicyId);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
