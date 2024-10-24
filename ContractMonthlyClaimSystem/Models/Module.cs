using ContractMonthlyClaimSystem.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class Module
    {
        [Key]
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }

        public ICollection<ClaimsModules> ClaimsModules { get; set; } = new List<ClaimsModules>();
    }
}
