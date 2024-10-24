using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class ProgrammeCoordinator
    {
        [Key]
        public string CoordinatorId { get; set; } // Unique identifier for the coordinator

        [Required]
        public string Name { get; set; } // Coordinator's first name

        [Required]
        public string Surname { get; set; } // Coordinator's surname

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Coordinator's email address

        [Required]
        [Phone]
        public string Phone { get; set; } // Coordinator's phone number
                                          // Foreign key to the User table
        public string UserId { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
