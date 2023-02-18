using Insurance.CustomerAPI.Models;
using MediatR;
using Insurance.CustomerAPI.Data;

namespace Insurance.CustomerAPI.Commands.CreateCustomer
{
    /// <summary>
    /// Command handler to create new customer
    /// </summary>
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<Customer>>
    {
        #region [Private Properties]

        private readonly CustomerDbContext _dbContext;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default setup
        /// </summary>
        /// <param name="dbContext"></param>
        public CreateCustomerCommandHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion [Constructor]

        #region [Public Methods]

        /// <summary>
        /// Create New Customer Handler
        /// </summary>
        /// <param name="request">Input Request</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Customer</returns>
        public async Task<Response<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Response<Customer> response = new Response<Customer>();
            // Assigning customer data from request input
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Mobile = request.Mobile,
                Address = request.Address,
                Gender = request.Gender,
                DOB = request.DOB
            };

            // Adding customer to db context
            _dbContext.Customers.Add(customer);
            // Saving data to table
            var result = await _dbContext.SaveChangesAsync();

            // If record created
            if (result > 0)
            {
                // Sends success response
                response.SetSuccess(customer);
            }

            return response;
        }

        #endregion [Public Methods]
    }
}
