using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class AcademicManager
    {
        [Key]
        public string ManagerId { get; set; } // Unique identifier for the manager

        [Required]
        public string Name { get; set; } // Manager's first name

        [Required]
        public string Surname { get; set; } // Manager's surname

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Manager's email address

        [Required]
        [Phone]
        public string Phone { get; set; } // Manager's phone number
                                          // Foreign key to the User table
        public string UserId { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
