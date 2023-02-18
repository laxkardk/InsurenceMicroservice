using PolicyMasterService.Models;
using MediatR;

namespace PolicyMasterService.Queries
{
    public class GetAllPolicyListQuery : IRequest<IEnumerable<PolicyMasterEntity>>
    {
    }
}
