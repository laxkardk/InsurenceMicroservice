using MediatR;
using PolicyMasterService.Models;

namespace PolicyMasterService.Commands
{
    /// <summary>
    /// Add policy command
    /// </summary>
    public class AddPolicyCmd : IRequest<MediatResponseEntity<PolicyMasterEntity>>
    {
        public string PolicyName { get; set; } = string.Empty;

        public string PolicyDescription { get; set; } = string.Empty;

        public string PolicyCategory { get; set; } = string.Empty;

        public DateTime PolicyLaunchDate { get; set; }
    }
}
