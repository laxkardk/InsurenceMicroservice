using Insurance.CustomerAPI.Data;
using Insurance.CustomerAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Insurance.CustomerAPI.Queries.GetAllCustomer
{
    /// <summary>
    /// Get All Customers Query Handler
    /// </summary>
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<Customer>>
    {
        #region [Private Properties]

        private readonly CustomerDbContext _context;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="context"></param>
        public GetAllCustomerQueryHandler(CustomerDbContext context)
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
        public async Task<IEnumerable<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken) =>
            await _context.Customers.ToListAsync();

        #endregion [Public Methods]
    }
}
