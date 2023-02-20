using Insurance.CustomerAPI.Models;
using MediatR;

namespace Insurance.CustomerAPI.Commands.DeleteCustomer
{
    /// <summary>
    /// Command to delete customer
    /// </summary>
    public class DeleteCustomerCommand : IRequest<Response<Customer>>
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        public int Id { get; set; }
    }
}
