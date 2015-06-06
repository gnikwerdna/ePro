using ePro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ePro.ViewModels
{
    public class ProductIndexData
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ComplianceForm> ComplianceForms { get; set; }
        public IEnumerable<Compliance> Compliances { get; set; }
        public IEnumerable<ProductCompliance> ProductCompliances { get; set; }
    }
}