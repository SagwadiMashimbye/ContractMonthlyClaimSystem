﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class AcademicManager
    {
        [Key]
        public int ManagerID { get; set; }
        [Required]
        public string ManagerName { get; set; }
        [Required]
        public string ManagerSurname { get; set; }
        [Required]
        public string ManagerEmail { get; set; }
        [Required]
        public string ManagerPhone { get; set; }
        [Required]
        public string ManagerPassword { get; set; }

        public ICollection<ApprovalProcess> ApprovalProcesses { get; set; } = new List<ApprovalProcess>();
    }
}
