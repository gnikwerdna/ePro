using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ePro.Models
{
    public class ComplianceCategory
    {
        [Key]
        public int ComplianceCategoryID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public virtual ICollection<ComplianceForm> ComplianceForms { get; set; }
    }
}