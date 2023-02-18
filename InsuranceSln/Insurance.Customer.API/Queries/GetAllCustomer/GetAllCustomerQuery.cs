using Insurance.CustomerAPI.Models;
using MediatR;

namespace Insurance.CustomerAPI.Queries.GetAllCustomer
{
    /// <summary>
    /// Get All Customers Query
    /// </summary>
    public class GetAllCustomerQuery : IRequest<IEnumerable<Customer>>
    {
    }
}
