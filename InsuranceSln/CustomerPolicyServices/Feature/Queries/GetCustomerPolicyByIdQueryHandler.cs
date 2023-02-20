using CustomerPolicyServices.Context;
using CustomerPolicyServices.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerPolicyServices.Feature.Queries
{
    public class GetCustomerPolicyByIdQueryHandler : IRequestHandler<GetCustomerPolicyByIdQuery, CustomerPolicy?>
    {
        #region [Private Properties]

        private readonly ServiceDbContext _context;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="context"></param>
        public GetCustomerPolicyByIdQueryHandler(ServiceDbContext context)
        {
            _context = context;
        }

        #endregion [Constructor]

        #region [Public Methods]

        /// <summary>
        /// Handler Methods
        /// </summary>
        /// <param name="request">Request Input</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>

        public async Task<CustomerPolicy?> Handle(GetCustomerPolicyByIdQuery request, CancellationToken cancellationToken) =>
            await _context.CustomerPolicy.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        #endregion [Public Methods]
    }
}
