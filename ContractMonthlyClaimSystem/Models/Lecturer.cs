﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class Lecturer
    {
        [Key]
        public int LecturerID { get; set; }
        [Required]
        public string LecturerName { get; set; }
        [Required]
        public string LecturerSurname { get; set; }
        [Required]
        public string LecturerPhone { get; set; }
        [Required]
        public string LecturerEmail { get; set; }
        [Required]
        public string LecturerPassword { get; set; }

        public ICollection<Claims> Claims { get; set; } = new List<Claims>();
        public ICollection<ReportMetadata> ReportMetadata { get; set; } = new List<ReportMetadata>();
    }
}
