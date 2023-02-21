using MediatR;
using PolicyMasterService.Models;
using PolicyMasterService.Data;
using PolicyMasterService.Common;

namespace PolicyMasterService.Commands
{
    public class AddPolicyCmdHandler : IRequestHandler<AddPolicyCmd, MediatResponseEntity<PolicyMasterEntity>>
    {
        private readonly PolicyMasterDBContext _policyMasterContext;

        public AddPolicyCmdHandler(PolicyMasterDBContext policyMasterContext)
        {
            _policyMasterContext = policyMasterContext;
        }

        #region Methods
        public async Task<MediatResponseEntity<PolicyMasterEntity>> Handle(AddPolicyCmd addPolicyCmdRequest, CancellationToken cancellationToken)
        {
            MediatResponseEntity<PolicyMasterEntity> response = new MediatResponseEntity<PolicyMasterEntity>();

            // Create Policy Master input
            PolicyMasterEntity policyMasterEntity = new PolicyMasterEntity
            {
                PolicyName = addPolicyCmdRequest.PolicyName,
                PolicyDescription = addPolicyCmdRequest.PolicyDescription,
                PolicyCategory = addPolicyCmdRequest.PolicyCategory,
                PolicyLaunchDate = addPolicyCmdRequest.PolicyLaunchDate,
                isActive = true
            };

            _policyMasterContext.PolicyMaster.Add(policyMasterEntity);

            // Save to DB
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

            return response;
        }

        #endregion Methods
    }
}
