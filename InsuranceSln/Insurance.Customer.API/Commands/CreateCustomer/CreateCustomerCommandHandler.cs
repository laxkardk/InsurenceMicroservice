using Insurance.CustomerAPI.Models;
using MediatR;
using Insurance.CustomerAPI.Data;

namespace Insurance.CustomerAPI.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly CustomerDbContext _dbContext;

        public CreateCustomerCommandHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var product = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Mobile = request.Mobile,
                Address = request.Address,
                Gender = request.Gender,
                DOB = request.DOB
            };

            _dbContext.Customers.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}
