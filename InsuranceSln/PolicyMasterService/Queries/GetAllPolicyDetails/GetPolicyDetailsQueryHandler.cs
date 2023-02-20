using PolicyMasterService.Models;
using PolicyMasterService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PolicyMasterService.Queries
{
    public class GetPolicyDetailsQueryHandler : IRequestHandler<GetPolicyDetailsQuery, PolicyMasterEntity?>
    {
        private readonly PolicyMasterDBContext _policyMasterContext;

        public GetPolicyDetailsQueryHandler(PolicyMasterDBContext policyMasterContext)
        {
            _policyMasterContext = policyMasterContext;
        }

        #region Methods

        /// <summary>
        /// Return async record using MediatR
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PolicyMasterEntity?> Handle(GetPolicyDetailsQuery request, CancellationToken cancellationToken) =>
            await GetPolicyMasterDetails(request);


        /// <summary>
        /// GetPolicyMasterDetails by policy id
        /// </summary>
        /// <param name="request">policy id request</param>
        /// <returns></returns>
        private async Task<PolicyMasterEntity?> GetPolicyMasterDetails(GetPolicyDetailsQuery request)
        {
            return await _policyMasterContext.PolicyMaster.FirstOrDefaultAsync(upd => upd.PolicyId == request.PolicyId);
        }

        #endregion Methods

    }
}
