using Insurance.CustomerAPI.Data;
using Insurance.CustomerAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Insurance.CustomerAPI.Queries.GetCustomerById
{
    /// <summary>
    /// Get Customer by Id Query handler
    /// </summary>
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        #region [Private Properties]

        private readonly CustomerDbContext _context;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="context"></param>
        public GetCustomerByIdQueryHandler(CustomerDbContext context)
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

        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken) =>
            await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        #endregion [Public Methods]
    }
}
