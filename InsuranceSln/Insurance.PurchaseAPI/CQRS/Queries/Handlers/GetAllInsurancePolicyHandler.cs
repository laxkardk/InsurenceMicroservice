using Insurance.PurchaseAPI.CQRS.Commands;
using Insurance.PurchaseAPI.Database;
using Insurance.PurchaseAPI.Models;
using Insurance.PurchaseAPI.Utility;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Insurance.PurchaseAPI.CQRS.Queries.Handlers
{
    public class GetAllInsurancePolicyHandler : IRequestHandler<GetAllInsurancePolicyCommand, IEnumerable<PurchaseInsuranceEntity>>
    {
        AppDbContext _appDbContext;
        public GetAllInsurancePolicyHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<PurchaseInsuranceEntity>> Handle(GetAllInsurancePolicyCommand request, CancellationToken cancellationToken)
        {
            var policies = await _appDbContext.PurchaseInsurance.ToListAsync();

            return
                policies.Select(policy => new PurchaseInsuranceEntity
                {
                    CustomerPolicyId = policy.CustomerPolicyId,
                    CustomerAddress = policy.CustomerAddress,
                    Price = policy.Price,
                    PaymentMethod = policy.PaymentMethod,
                    Quantity = policy.Quantity,
                    IsConfirm = policy.IsConfirm,
                    CreatedBy= policy.CreatedBy,
                    CreatedDate= policy.CreatedDate,
                    ModifiedBy= policy.ModifiedBy,
                    ModifiedDate= policy.ModifiedDate
                });
        }
    }
}
