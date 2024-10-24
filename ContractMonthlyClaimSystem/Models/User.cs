using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } // This will store the hashed password

        [Required]
        public string Role { get; set; }

        [Required]
        public string Phone { get; set; }// Roles could include Lecturer, Coordinator, Manager, etc.
        public ICollection<AcademicManager> AcademicManagers { get; set; } = new List<AcademicManager>();
        public ICollection<ProgrammeCoordinator> ProgrammeCoordinators { get; set; } = new List<ProgrammeCoordinator>();
        public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
    }
}
