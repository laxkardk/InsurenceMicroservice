using Insurance.CustomerAPI.Data;
using Insurance.CustomerAPI.Models;
using MediatR;

namespace Insurance.CustomerAPI.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Customer>
    {
        private readonly CustomerDbContext _dbContext;

        public DeleteCustomerCommandHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var product = _dbContext.Customers.FirstOrDefault(p => p.Id == request.Id);

            if (product is not null)
            {

                _dbContext.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
            return product;
        }
    }
}
