using Insurance.CustomerAPI.Data;
using Insurance.CustomerAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Insurance.CustomerAPI.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly CustomerDbContext _context;
        public GetCustomerByIdQueryHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken) =>
            await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ?? new Customer();
    }
}
