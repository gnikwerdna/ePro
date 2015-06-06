using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ePro.Models
{
    public class ComplianceItems
    {

        [Key]
        public int ComplianceItemsID { get; set; }
        public string ItemName { get; set; }
        public virtual ICollection<Compliance> Compliance { get; set; }
    }
}