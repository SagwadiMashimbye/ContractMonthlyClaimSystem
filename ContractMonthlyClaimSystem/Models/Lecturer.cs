using ContractMonthlyClaimSystem.Models;
using System.ComponentModel.DataAnnotations;

public class Lecturer
{
    [Key]
    public string LecturerId { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    // Foreign key to the User table
    public string UserId { get; set; }

    // Navigation property
    public User User { get; set; }
}
