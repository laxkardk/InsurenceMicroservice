using Insurance.CustomerAPI.Data;
using Insurance.CustomerAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Insurance.CustomerAPI.Queries.GetAllCustomer
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<Customer>>
    {
        private readonly CustomerDbContext _context;
        public GetAllCustomerQueryHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken) =>
            await _context.Customers.ToListAsync();
    }
}
