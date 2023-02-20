using CustomerPolicyServices.Context;
using CustomerPolicyServices.Models;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CustomerPolicyServices.Feature.Commands
{
    public class CreateCustomerPolicyCommandHandler : IRequestHandler<CreateCustomerPolicyCommand, Response<CustomerPolicy>>
    {
        #region [Private Properties]

        private readonly ServiceDbContext _dbContext;

        #endregion [Private Properties]

        #region [Constructor]

        /// <summary>
        /// Default setup
        /// </summary>
        /// <param name="dbContext"></param>
        public CreateCustomerPolicyCommandHandler(ServiceDbContext dbContext)
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
        public async Task<Response<CustomerPolicy>> Handle(CreateCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            Response<CustomerPolicy> response = new Response<CustomerPolicy>();
            // Assigning customer Policy data from request input
            var customer = new CustomerPolicy
            {
                CustomerId = request.CustomerId,
                PolicyId = request.PolicyId,
                Duration = request.Duration,
                IsActive = request.IsActive,
                Bonus = request.Bonus,
                MaturityDate = request.MaturityDate,
                PolicyDescription = request.PolicyDescription,
                PolicyType = request.PolicyType,
                PolicyAmount = request.PolicyAmount,
                MaturityAmount = request.MaturityAmount
            };

            // Adding customer to db context
            _dbContext.CustomerPolicy.Add(customer);
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
