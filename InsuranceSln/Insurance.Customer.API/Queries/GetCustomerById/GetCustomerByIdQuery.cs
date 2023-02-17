using Insurance.CustomerAPI.Models;
using MediatR;

namespace Insurance.CustomerAPI.Queries.GetCustomerById
{
    /// <summary>
    /// Get Customer by Id Query
    /// </summary>
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }
}
