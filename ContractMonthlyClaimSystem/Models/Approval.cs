using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractMonthlyClaimSystem.Models
{
    public class Approval
    {
        [Key]
        public string ApprovalId { get; set; }

        [ForeignKey("Claim")]
        public string ClaimId { get; set; }
        public Claim Claim { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string ApprovedBy { get; set; } // Store the user who approved
    }
}
