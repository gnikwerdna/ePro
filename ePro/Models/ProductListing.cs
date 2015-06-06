using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ePro.Models
{
    public class ProductListing
    {
        [Key]
        public int ProductListingID { get; set; }
        [Required]
        [Display(Name="Product Name")]
        public string ProductName { get; set; }
        public string Source { get; set; }
        public virtual ICollection<ComplianceForm> ComplianceForms { get; set; }



    }
}