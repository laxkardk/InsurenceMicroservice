using PolicyMasterService.Models;
using PolicyMasterService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PolicyMasterService.Queries
{
    public class GetAllPolicyListQueryHandler : IRequestHandler<GetAllPolicyListQuery, IEnumerable<PolicyMasterEntity>>
    {

        private readonly PolicyMasterDBContext _context;

        public GetAllPolicyListQueryHandler(PolicyMasterDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PolicyMasterEntity>> Handle(GetAllPolicyListQuery request, CancellationToken cancellationToken) =>
            await _context.PolicyMaster.ToListAsync();
    }
}
