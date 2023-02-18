using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insurance.CustomerAPI.Models
{
    public class CustomerAuthentication
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        /// <summary>
        /// </summary>
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public Customer? Customer { get; set; } = new Customer();
    }
}
