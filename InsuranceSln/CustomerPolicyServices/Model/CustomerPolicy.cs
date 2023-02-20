using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerPolicyServices.Model
{
    public class CustomerPolicy
    {
        /// <summary>
        /// Identity Primary key field, Unique Policy Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal PolicyId { get; set; }
        public string Duration { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public decimal Bonus { get; set; }
        public DateTime MaturityDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PolicyType { get; set; } = string.Empty;
        public decimal PolicyAmount { get; set; }
        public decimal MaturityAmount { get; set; }
    }
}
