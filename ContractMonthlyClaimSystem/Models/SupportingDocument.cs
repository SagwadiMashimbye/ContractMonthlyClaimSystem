using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractMonthlyClaimSystem.Models
{
    public class SupportingDocument
    {
        [Key]
        public string DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string FilePath { get; set; }

        [ForeignKey("Claim")]
        public string ClaimId { get; set; }
        public Claim Claim { get; set; }
        public DateTime Date { get; set; }
    }
}
