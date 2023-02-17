using Insurance.CustomerAPI.Models;
using MediatR;
using Insurance.CustomerAPI.Data;

namespace Insurance.CustomerAPI.Commands.CreateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly CustomerDbContext _dbContext;

        public UpdateCustomerCommandHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var product = _dbContext.Customers.FirstOrDefault(p => p.Id == request.Id);

            if (product is not null)
            {

                product.Name = request.Name;
                product.Email = request.Email;
                product.Mobile = request.Mobile;
                product.Address = request.Address;
                product.Gender = request.Gender;
                product.DOB = request.DOB;
            }

            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}
