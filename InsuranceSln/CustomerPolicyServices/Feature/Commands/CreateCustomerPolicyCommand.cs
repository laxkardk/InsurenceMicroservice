using Azure;
using CustomerPolicyServices.Models;
using MediatR;

namespace CustomerPolicyServices.Feature.Commands
{
    public class CreateCustomerPolicyCommand : IRequest<Models.Response<CustomerPolicy>>
    {
        /// <summary>
        /// Customer Policy Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// CustomerId from other services
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// PolicyId from other services
        /// </summary>
        public decimal PolicyId { get; set; }
        /// <summary>
        /// Customer Policy Duration
        /// </summary>
        public string Duration { get; set; } = string.Empty;
        /// <summary>
        /// Customer Policy IsActive
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Customer Policy Bonus
        /// </summary>
        public decimal Bonus { get; set; }
        /// <summary>
        /// Customer Policy MaturityDate
        /// </summary>
        public DateTime MaturityDate { get; set; }
        /// <summary>
        /// Customer Policy Description
        /// </summary>
        public string PolicyDescription { get; set; } = string.Empty;
        /// <summary>
        /// Customer Policy PolicyType
        /// </summary>
        public string PolicyType { get; set; } = string.Empty;
        /// <summary>
        /// Customer Policy PolicyAmount
        /// </summary>
        public decimal PolicyAmount { get; set; }
        /// <summary>
        /// Customer Policy  MaturityAmount
        /// </summary>
        public decimal MaturityAmount { get; set; }
    }
}
