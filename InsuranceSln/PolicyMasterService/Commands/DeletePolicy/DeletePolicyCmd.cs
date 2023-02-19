using MediatR;
using PolicyMasterService.Models;

namespace PolicyMasterService.Commands
{
    /// <summary>
    /// Delete policy command
    /// </summary>
    public class DeletePolicyCmd : IRequest<MediatResponseEntity<PolicyMasterEntity>>
    {
        public decimal PolicyId { get; set; }
    }
}
