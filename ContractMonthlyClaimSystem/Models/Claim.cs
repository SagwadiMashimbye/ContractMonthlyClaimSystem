using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractMonthlyClaimSystem.Models
{
    public class Claim
    {
        [Key]
        public string ClaimId { get; set; }

        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public DateTime ClaimDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount {  get; set; }

        public string ClaimStatus { get; set; }
        public int HoursWorked { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HourlyRate { get; set; }

        public ICollection<ClaimDetail> ClaimDetails { get; set; } = new List<ClaimDetail>();
    }
}
