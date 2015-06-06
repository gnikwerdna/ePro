using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ePro.Models
{
    public class ComplianceForm
    {
         [Key]
        public int ComplianceFormID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public int? ComplianceCategoryID { get; set; }
        public virtual ComplianceCategory ComplianceCategory { get; set; }
        public virtual ICollection<Compliance> Compliances { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}