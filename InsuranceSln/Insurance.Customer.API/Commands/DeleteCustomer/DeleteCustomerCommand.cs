using Insurance.CustomerAPI.Models;
using MediatR;

namespace Insurance.CustomerAPI.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
