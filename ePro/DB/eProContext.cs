using ePro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ePro.DB
{
    public class eProContext : DbContext
    {
        public DbSet<ComplianceForm> ComplianceForm { get; set; }
        public DbSet<Compliance> Compliance { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ComplianceCategory> ComplianceCategory { get; set; }
        public DbSet<ComplianceItems> ComplianceItems { get; set; }
        public DbSet<ProductCompliance> ProductCompliance { get; set; }
        

    }
}