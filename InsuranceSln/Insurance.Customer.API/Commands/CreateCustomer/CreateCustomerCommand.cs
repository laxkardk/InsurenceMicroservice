using Insurance.CustomerAPI.Models;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insurance.CustomerAPI.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Customer>
    {

        /// <summary>
        /// Customer Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Customer Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Customer Mobile
        /// </summary>
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// Customer Address
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Customer Customer
        /// </summary>
        public string Gender { get; set; } = string.Empty;


        /// <summary>
        /// Customer Date of Birth
        /// </summary>
        public DateTime DOB { get; set; }
    }
}
