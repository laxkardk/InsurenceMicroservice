using MediatR;
using PolicyMasterService.Models;

namespace PolicyMasterService.Commands
{
    /// <summary>
    /// Update policy command
    /// </summary>
    public class UpdatePolicyCmd : IRequest<MediatResponseEntity<PolicyMasterEntity>>
    {
        public decimal PolicyId { get; set; }

        public string PolicyName { get; set; } = string.Empty;

        public string PolicyDescription { get; set; } = string.Empty;

        public string PolicyCategory { get; set; } = string.Empty;

        public DateTime PolicyLaunchDate { get; set; }

        public bool isActive { get; set; }
    }
}
