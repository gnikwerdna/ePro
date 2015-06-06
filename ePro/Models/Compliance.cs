using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ePro.Models
{
    public class Compliance
    {
        [Key]
        public int ComplinanceID { get; set; }
        public int ComplianceFormID { get; set; }
        public int ComplianceitemsID { get; set; }
        public string Description { get; set; }

        public virtual ComplianceForm ComplianceForm { get; set; }
        public virtual ComplianceItems ComplianceItem { get; set; }
    }

    /*
     public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; } */
}