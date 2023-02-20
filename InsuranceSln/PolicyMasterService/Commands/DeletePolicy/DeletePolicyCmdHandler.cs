using MediatR;
using PolicyMasterService.Models;
using PolicyMasterService.Data;
using PolicyMasterService.Common;

namespace PolicyMasterService.Commands
{
    public class DeletePolicyCmdHandler : IRequestHandler<DeletePolicyCmd, MediatResponseEntity<PolicyMasterEntity>>
    {
        private readonly PolicyMasterDBContext _policyMasterContext;

        public DeletePolicyCmdHandler(PolicyMasterDBContext policyMasterContext)
        {
            _policyMasterContext = policyMasterContext;
        }

        #region Methods

        public async Task<MediatResponseEntity<PolicyMasterEntity>> Handle(DeletePolicyCmd deletePolicyCmdRequest, CancellationToken cancellationToken)
        {
            MediatResponseEntity<PolicyMasterEntity> response = new MediatResponseEntity<PolicyMasterEntity>();

            var delPolicy = _policyMasterContext.PolicyMaster.FirstOrDefault(upd => upd.PolicyId == deletePolicyCmdRequest.PolicyId);

            // Delete Policy Master input
            if (delPolicy != null)
            {
                //Remove policy
                _policyMasterContext.Remove(delPolicy);

                //Save Db changes
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
