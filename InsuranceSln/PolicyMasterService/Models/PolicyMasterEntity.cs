using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolicyMasterService.Models
{
    /// <summary>
    /// Policy Master Entity
    /// </summary>
    public class PolicyMasterEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal PolicyId { get; set; }

        public string PolicyName { get; set; } = string.Empty;

        public string PolicyDescription { get; set; } = string.Empty;

        public string PolicyCategory { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool isActive { get; set; }
    }
}
