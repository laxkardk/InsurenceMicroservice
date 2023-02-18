using Insurance.CustomerAPI.Models;
using MediatR;
using Insurance.CustomerAPI.Data;

namespace Insurance.CustomerAPI.Commands.CreateCustomer
{
    /// <summary>
    /// Command handler to delete customer
    /// </summary>
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<Customer>>
    {
        #region [Private Properties]

        private readonly CustomerDbContext _dbContext;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="dbContext">Customer Database Context</param>
        public UpdateCustomerCommandHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion [Constructor]

        #region [Public Methods]

        /// <summary>
        /// To update the existing customer
        /// </summary>
        /// <param name="request">Input request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        public async Task<Response<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Response<Customer> response = new Response<Customer>();
            // Gets first customer record as per Customer Id
            var customer = _dbContext.Customers.FirstOrDefault(p => p.Id == request.Id);

            // If customer record found than update the record
            if (customer is not null)
            {
                customer.Name = request.Name;
                customer.Email = request.Email;
                customer.Mobile = request.Mobile;
                customer.Address = request.Address;
                customer.Gender = request.Gender;
                customer.DOB = request.DOB;
                // Updates the record into table
                var result = await _dbContext.SaveChangesAsync();

                // If record update
                if (result > 0)
                {
                    // Sends success response
                    response.SetSuccess(customer);
                }
            }
            else
            {
                response.SetError("No Record found to delete");
            }
            return response;
        }

        #endregion [Public Methods]
    }
}