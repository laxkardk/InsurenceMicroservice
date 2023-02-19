using PolicyMasterService.Models;
using MediatR;

namespace PolicyMasterService.Queries
{
    public class GetPolicyDetailsQuery : IRequest<PolicyMasterEntity>
    {
        public decimal PolicyId { get; set; }
    }
}
