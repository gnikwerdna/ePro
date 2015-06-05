using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ePro.ViewModels
{
    public class AssignedComplianceFormData
    {
        public int ComplianceFormID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}