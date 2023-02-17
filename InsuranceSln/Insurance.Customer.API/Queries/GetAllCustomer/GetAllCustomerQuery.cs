using Insurance.CustomerAPI.Models;
using MediatR;

namespace Insurance.CustomerAPI.Queries.GetAllCustomer
{
    /// <summary>
    /// Get Customer by Id Query
    /// </summary>
    public class GetAllCustomerQuery : IRequest<IEnumerable<Customer>>
    {
    }
}
