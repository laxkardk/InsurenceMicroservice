using Insurance.CustomerAPI.Data;
using Insurance.CustomerAPI.Models;
using MediatR;

namespace Insurance.CustomerAPI.Commands.DeleteCustomer
{
    /// <summary>
    /// Command handler to delete customer
    /// </summary>
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<Customer>>
    {
        #region [Private Properties]

        private readonly CustomerDbContext _dbContext;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default Initialization
        /// </summary>
        /// <param name="dbContext">Customer Database Context</param>
        public DeleteCustomerCommandHandler(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion [Constructor]

        #region [Public Methods]

        /// <summary>
        /// To delete the existing customer
        /// </summary>
        /// <param name="request">Input request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        public async Task<Response<Customer>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Response<Customer> response = new Response<Customer>();
            // Gets first customer record as per Customer Id
            var customer = _dbContext.Customers.FirstOrDefault(p => p.Id == request.Id);

            // If customer record found than delete the record
            if (customer is not null)
            {
                // Removes customer from list
                _dbContext.Remove(customer);
                // Updates the record into table
                var result = await _dbContext.SaveChangesAsync();

                // If record deleted
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

            // Sends Failed Response
            return response;
        }

        #endregion [Public Method]
    }
}
