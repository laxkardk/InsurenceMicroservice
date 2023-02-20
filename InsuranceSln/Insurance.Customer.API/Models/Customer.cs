using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance.CustomerAPI.Models
{
    /// <summary>
    /// Customer Entity Model
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
