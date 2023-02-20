using MediatR;
using PolicyMasterService.Models;
using PolicyMasterService.Data;
using PolicyMasterService.Common;

namespace PolicyMasterService.Commands
{
    public class UpdatePolicyCmdHandler : IRequestHandler<UpdatePolicyCmd, MediatResponseEntity<PolicyMasterEntity>>
    {
        private readonly PolicyMasterDBContext _policyMasterContext;

        public UpdatePolicyCmdHandler(PolicyMasterDBContext policyMasterContext)
        {
            _policyMasterContext = policyMasterContext;
        }

        #region Methods

        public async Task<MediatResponseEntity<PolicyMasterEntity>> Handle(UpdatePolicyCmd updatePolicyCmdRequest, CancellationToken cancellationToken)
        {
            MediatResponseEntity<PolicyMasterEntity> response = new MediatResponseEntity<PolicyMasterEntity>();

            var updPolicy = _policyMasterContext.PolicyMaster.FirstOrDefault(upd => upd.PolicyId == updatePolicyCmdRequest.PolicyId);

            // Update Policy Master input
            if (updPolicy != null)
            {
                updPolicy.PolicyName = updatePolicyCmdRequest.PolicyName;
                updPolicy.PolicyDescription = updatePolicyCmdRequest.PolicyDescription;
                updPolicy.PolicyCategory = updatePolicyCmdRequest.PolicyCategory;
                updPolicy.PolicyLaunchDate = updatePolicyCmdRequest.PolicyLaunchDate;
                updPolicy.isActive = updatePolicyCmdRequest.isActive;

                var result = await _policyMasterContext.SaveChangesAsync();

                //On Success
                if (result > 0)
                {
                    response.StatusCode = (int)ResponseCodes.Success;
                    response.Status = Constants.ResponseSuccess;
                }
                else
                {
                    //On Fail
                    response.StatusCode = (int)ResponseCodes.Failed;
                    response.Status = Constants.ResponseFailure;
                }
            }
            else
            {
                response.StatusCode = (int)ResponseCodes.NotFound;
                response.Status = Constants.ResponseNotFound;
            }

            return response;
        }

        #endregion Methods
    }
}
