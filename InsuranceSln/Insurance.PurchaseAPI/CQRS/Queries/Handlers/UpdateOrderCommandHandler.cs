using Insurance.PurchaseAPI.CQRS.Commands;
using Insurance.PurchaseAPI.Database;
using Insurance.PurchaseAPI.Models;
using Insurance.PurchaseAPI.Utility;
using MediatR;

namespace Insurance.PurchaseAPI.CQRS.Queries.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ApiResponseEntity<PurchaseInsuranceEntity>>
    {
        AppDbContext _appDbContext;
        public UpdateOrderCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ApiResponseEntity<PurchaseInsuranceEntity>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            ApiResponseEntity<PurchaseInsuranceEntity> response = new ApiResponseEntity<PurchaseInsuranceEntity>();

            var updPolicy = _appDbContext.PurchaseInsurance.FirstOrDefault(upd => upd.CustomerPolicyId == request.CustomerPolicyId);

            if (updPolicy != null)
            {
                updPolicy.CustomerAddress = request.CustomerAddress;
                updPolicy.Price = request.Price;
                updPolicy.PaymentMethod = request.PaymentType;
                updPolicy.Quantity = request.PolicyQuantity;
                updPolicy.IsConfirm = request.IsConfirm;

                var result = await _appDbContext.SaveChangesAsync();

                if (result > 0)
                {
                    response.Status = MsgConstant.ResponseSuccess;
                }
                else
                {
                    response.Status = MsgConstant.ResponseFailure;
                }
            }
            else
            {
                response.Status = MsgConstant.ResponseNotFound;
            }

            return response;
        }
    }
}
