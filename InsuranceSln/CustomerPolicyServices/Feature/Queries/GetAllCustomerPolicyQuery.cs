using CustomerPolicyServices.Models;
using MediatR;

namespace CustomerPolicyServices.Feature.Queries
{
    public class GetAllCustomerPolicyQuery : IRequest<IEnumerable<CustomerPolicy>>
    {
    }
}
