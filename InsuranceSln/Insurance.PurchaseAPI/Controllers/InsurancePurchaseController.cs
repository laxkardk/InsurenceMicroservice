using Insurance.PurchaseAPI.CQRS.Commands;
using Insurance.PurchaseAPI.Models;
using Insurance.PurchaseAPI.Utility;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ResponseStatus = Insurance.PurchaseAPI.Models.ResponseStatus;

namespace Insurance.PurchaseAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InsurancePurchaseController : ControllerBase
    {
        private readonly ILogger<InsurancePurchaseController> _logger;
        private readonly CommonMessage _appConfig;
        private readonly IMediator _mediator;
        ResponseCommandModel response = new ResponseCommandModel();

        public InsurancePurchaseController(ILogger<InsurancePurchaseController> logger,
                                            IOptions<CommonMessage> optionsAccessor, IMediator mediator)
        {
            _logger = logger;
            _appConfig = optionsAccessor.Value;
            _mediator = mediator;
        }
        /// <summary>
        /// Method for get all policy
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetAllInsurancePolicy")]
        public async Task<ResponseCommandModel> GetAllInsurancePolicy()
        {
            try
            {
                response.status = ResponseStatus.success.ToString();
                response.code = StatusCodes.Status200OK;
                response.message = _appConfig.status200OK;
                response.data = await _mediator.Send(new GetAllInsurancePolicyCommand()); 
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured during Place Order Action Method. Here is the Exception message :" + ex.Message);
                response.status = ResponseStatus.failure.ToString();
                response.code = StatusCodes.Status500InternalServerError;
                response.message = _appConfig.statusCode500;
                response.data = null;
                return response;
            }

        }
        /// <summary>
        /// Method for purchasing policy
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost (Name = "PlaceOrder")]
        public async Task<ResponseCommandModel> PlaceOrder([FromBody] PlaceOrderCommand placeCommand)
        {
            try
                {
                    response.status = ResponseStatus.success.ToString();
                    response.code = StatusCodes.Status200OK;
                    response.message = _appConfig.status200OK;
                    var result = await _mediator.Send(placeCommand);
                    if(result.Status == MsgConstant.ResponseSuccess)
                       response.data = MsgConstant.ResponseAdd;
                    else
                       response.data = MsgConstant.ResponseFailure;
                _logger.LogInformation("Order Successfully Placed for Policy ID :" + placeCommand.CustomerPolicyId);
                    return response;
                }
            catch(Exception ex) 
                {
                    _logger.LogError("Exception Occured during Place Order Action Method. Here is the Exception message :" + ex.Message);
                    response.status = ResponseStatus.failure.ToString();
                    response.code = StatusCodes.Status500InternalServerError;
                    response.message = _appConfig.statusCode500;
                    response.data = null;
                    return response;
            }
                
        }

        /// <summary>
        /// Update to an existing policy
        /// </summary>
        /// <param name="updateCommand"></param>
        /// <returns></returns>
        [HttpPost(Name = "UpdateOrder")]
        public async Task<ResponseCommandModel> UpdateOrder([FromBody] UpdateOrderCommand updateCommand)
        {
            try
            {
                response.status = ResponseStatus.success.ToString();
                response.code = StatusCodes.Status200OK;
                response.message = _appConfig.status200OK;
                var policy = await _mediator.Send(updateCommand); 
                if(policy.Status == MsgConstant.ResponseSuccess)
                    response.data = MsgConstant.ResponseUpdate;
                else
                    response.data = MsgConstant.ResponseFailure;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured during Update Order Method. Here is the Exception message :" + ex.Message);
                _logger.LogTrace(ex.Message);
                response.status = ResponseStatus.failure.ToString();
                response.code = StatusCodes.Status500InternalServerError;
                response.message = _appConfig.statusCode500;
                response.data = null;
                return response;
            }
        }
        /// <summary>
        /// Delete an existing policy
        /// </summary>
        /// <param name="customerPolicyId"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteOrder")]
        public async Task<ResponseCommandModel> DeleteOrder(int customerPolicyId)
        {
            try
            {
                response.status = ResponseStatus.success.ToString();
                response.code = StatusCodes.Status200OK;
                response.message = _appConfig.status200OK;
                DeleteOrderCommand deleteCommand = new DeleteOrderCommand();
                deleteCommand.CustomerPolicyId = customerPolicyId;
                var policy = await _mediator.Send(deleteCommand);
                if (policy.Status == MsgConstant.ResponseSuccess)
                    response.data = MsgConstant.ResponseDelete;
                else
                    response.data = MsgConstant.ResponseFailure;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured during Delete Order Method. Here is the Exception message :" + ex.Message);
                _logger.LogTrace(ex.Message);
                response.status = ResponseStatus.failure.ToString();
                response.code = StatusCodes.Status500InternalServerError;
                response.message = _appConfig.statusCode500;
                response.data = null;
                return response;
            }
        }
        /// <summary>
        /// Confirn an policy purchase
        /// </summary>
        /// <param name="confirmCommand"></param>
        /// <returns></returns>
        [HttpPatch(Name = "ConfirmOrder")]
        public async Task<ResponseCommandModel> ConfirmOrder(int customerPolicyId)
        {
            
            try
            {
                response.status = ResponseStatus.success.ToString();
                response.code = StatusCodes.Status200OK;
                response.message = _appConfig.status200OK;
                ConfirmOrderCommand confirmCommand = new ConfirmOrderCommand();
                confirmCommand.CustomerPolicyId = customerPolicyId;
                var policy = await _mediator.Send(confirmCommand);
                if (policy.Status == MsgConstant.ResponseSuccess)
                    response.data = MsgConstant.ResponseConfirm;
                else
                    response.data = MsgConstant.ResponseFailure;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured during Confirm Order Method. Here is the Exception message :" + ex.Message);
                _logger.LogTrace(ex.Message);
                response.status = ResponseStatus.failure.ToString();
                response.code = StatusCodes.Status500InternalServerError;
                response.message = _appConfig.statusCode500;
                response.data = null;
                return response;
            }
        }
    }
}
