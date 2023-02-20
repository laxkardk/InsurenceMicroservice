using CustomerPolicyServices.Context;
using CustomerPolicyServices.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerPolicyServices.Feature.Queries
{
    public class GetAllCustomerPolicyQueryHandler : IRequestHandler<GetAllCustomerPolicyQuery, IEnumerable<CustomerPolicy>>
    {
        #region [Private Properties]

        private readonly ServiceDbContext _context;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="context"></param>
        public GetAllCustomerPolicyQueryHandler(ServiceDbContext context)
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
        public async Task<IEnumerable<CustomerPolicy>> Handle(GetAllCustomerPolicyQuery request, CancellationToken cancellationToken) =>
            await _context.CustomerPolicy.ToListAsync();

        #endregion [Public Methods]
    }
}
