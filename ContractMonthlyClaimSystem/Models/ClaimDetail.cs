using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractMonthlyClaimSystem.Models
{
    public class ClaimDetail
    {
        [Key]
        public int ClaimDetailId { get; set; }

        [ForeignKey("Claim")]
        public string ClaimId { get; set; } // This should match the ClaimId type

        public Claim Claim { get; set; } // Navigation property

        [Required]
        public string ModelName { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal TotalClaimAmount { get; set; }
        public int TotalHoursWorked { get; set; }
    }
}
