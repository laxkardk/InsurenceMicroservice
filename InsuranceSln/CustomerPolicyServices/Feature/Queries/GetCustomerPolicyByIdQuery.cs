using CustomerPolicyServices.Models;
using MediatR;

namespace CustomerPolicyServices.Feature.Queries
{
    /// <summary>
    /// Get CustomerPolicy by Id Query
    /// </summary>
    public class GetCustomerPolicyByIdQuery : IRequest<CustomerPolicy?>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }
}
