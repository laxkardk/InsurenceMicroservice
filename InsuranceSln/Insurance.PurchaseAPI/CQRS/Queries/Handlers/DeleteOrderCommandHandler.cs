using Insurance.PurchaseAPI.CQRS.Commands;
using Insurance.PurchaseAPI.Database;
using Insurance.PurchaseAPI.Models;
using Insurance.PurchaseAPI.Utility;
using MediatR;

namespace Insurance.PurchaseAPI.CQRS.Queries.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ApiResponseEntity<PurchaseInsuranceEntity>>
    {
        AppDbContext _appDbContext;
        public DeleteOrderCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ApiResponseEntity<PurchaseInsuranceEntity>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            ApiResponseEntity<PurchaseInsuranceEntity> response = new ApiResponseEntity<PurchaseInsuranceEntity>();

            var delPolicy = _appDbContext.PurchaseInsurance.FirstOrDefault(del => del.CustomerPolicyId == request.CustomerPolicyId);

            if (delPolicy != null)
            {
                _appDbContext.Remove(delPolicy);

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
