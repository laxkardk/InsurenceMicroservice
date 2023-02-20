using Insurance.PurchaseAPI.CQRS.Commands;
using Insurance.PurchaseAPI.Database;
using Insurance.PurchaseAPI.Models;
using Insurance.PurchaseAPI.Utility;
using MediatR;
namespace Insurance.PurchaseAPI.CQRS.Queries.Handlers
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, ApiResponseEntity<PurchaseInsuranceEntity>>
    {
        AppDbContext _appDbContext;
        public PlaceOrderCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ApiResponseEntity<PurchaseInsuranceEntity>> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            ApiResponseEntity<PurchaseInsuranceEntity> response = new ApiResponseEntity<PurchaseInsuranceEntity>();

            PurchaseInsuranceEntity policy = new PurchaseInsuranceEntity
            {
                CustomerPolicyId = request.CustomerPolicyId,
                CustomerAddress = request.CustomerAddress,
                Price = request.Price,
                PaymentMethod = request.PaymentType,
                Quantity = request.PolicyQuantity,
                IsConfirm = request.IsConfirm,
                CreatedBy = request.CreatedBy,
                CreatedDate = request.CreatedDate,
                ModifiedBy = request.ModifiedBy,
                ModifiedDate = request.ModifiedDate,
            };

            _appDbContext.PurchaseInsurance.Add(policy);
            var result = await _appDbContext.SaveChangesAsync();

            if (result > 0)
            {
                response.Status = MsgConstant.ResponseSuccess;
            }
            else
            {
                response.Status = MsgConstant.ResponseFailure;
            }

            return response;
        }
    }
}
