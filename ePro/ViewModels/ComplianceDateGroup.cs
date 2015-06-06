using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ePro.ViewModels
{
    public class ComplianceDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? ComplianceDate { get; set; }

        public int ComplianceCount { get; set; }
    }
}