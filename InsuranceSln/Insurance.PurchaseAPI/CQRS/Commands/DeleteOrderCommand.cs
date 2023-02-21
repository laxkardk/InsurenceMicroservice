using Insurance.PurchaseAPI.Models;
using Insurance.PurchaseAPI.Database;
using MediatR;
namespace Insurance.PurchaseAPI.CQRS.Commands
{
    public class DeleteOrderCommand : IRequest<ApiResponseEntity<PurchaseInsuranceEntity>>
    {
        public int CustomerPolicyId { get; set; }
    }
}
