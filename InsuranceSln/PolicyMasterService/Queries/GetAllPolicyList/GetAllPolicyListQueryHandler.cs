using PolicyMasterService.Models;
using PolicyMasterService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PolicyMasterService.Queries
{
    public class GetAllPolicyListQueryHandler : IRequestHandler<GetAllPolicyListQuery, IEnumerable<PolicyMasterEntity>>
    {

        private readonly PolicyMasterDBContext _policyMasterContext;

        public GetAllPolicyListQueryHandler(PolicyMasterDBContext context)
        {
            _policyMasterContext = context;
        }

        /// <summary>
        /// Return async list using MediatR
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PolicyMasterEntity>> Handle(GetAllPolicyListQuery request, CancellationToken cancellationToken) =>
            await GetPolicyMasterList();


        /// <summary>
        /// Get all policies
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<PolicyMasterEntity>> GetPolicyMasterList()
        {
            var policyList = await _policyMasterContext.PolicyMaster.ToListAsync();

            return
                policyList.Select(policy => new PolicyMasterEntity
                {
                    PolicyId = policy.PolicyId,
                    PolicyName = policy.PolicyName,
                    PolicyCategory = policy.PolicyCategory,
                    PolicyDescription = policy.PolicyDescription,
                    Price = policy.Price,
                    isActive = policy.isActive
                });
        }
    }
}
