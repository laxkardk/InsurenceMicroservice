using Insurance.PurchaseAPI.Models;
using Insurance.PurchaseAPI.Database;
using MediatR;
namespace Insurance.PurchaseAPI.CQRS.Commands
{
    public class ConfirmOrderCommand : IRequest<ApiResponseEntity<PurchaseInsuranceEntity>>
    {
        public int CustomerPolicyId { get; set; }
    }
}
