﻿using ContractMonthlyClaimSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractMonthlyClaimSystem.Models
{
    public class ApprovalProcess
    {
        [Key]
        public int ApprovalID { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime ApprovalDate { get; set; }

        [ForeignKey("Claims")]
        public int ClaimID { get; set; }
        public Claims Claims { get; set; }

        [ForeignKey("Coordinator")]
        public int CoordinatorID { get; set; }
        public ProgrammeCoordinator Coordinator { get; set; }

        [ForeignKey("Manager")]
        public int ManagerID { get; set; }
        public AcademicManager Manager { get; set; }

        public string? Feedback { get; set; }

        public ICollection<ClaimSubmissionInfo> infos { get; set; } = new List<ClaimSubmissionInfo>();
        public ICollection<ReportMetadata> ReportMetadata { get; set; } = new List<ReportMetadata>();
    }

}
