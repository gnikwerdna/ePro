using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ePro.Models
{
    public class ProductCompliance
    {
       
        public int ProductComplianceID { get; set; }
        [Key][Column(Order=0)]
        public int ProductListingID { get; set; }
        [Key] [Column(Order = 1)]
        public int ComplianceItemsID { get; set; }
        public int Checked { get; set; }
        public virtual Product Product { get; set; }
        public virtual ComplianceItems ComplianceItem { get; set; }
    }
}