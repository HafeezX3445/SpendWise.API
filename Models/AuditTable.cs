using System.ComponentModel.DataAnnotations;

namespace SpendWise.API.Models
{
    public class AuditTable
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [MaxLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
