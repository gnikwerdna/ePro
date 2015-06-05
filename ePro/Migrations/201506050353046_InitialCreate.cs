namespace ePro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compliances",
                c => new
                    {
                        ComplinanceID = c.Int(nullable: false, identity: true),
                        ComplianceFormID = c.Int(nullable: false),
                        value = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ComplinanceID)
                .ForeignKey("dbo.ComplianceForms", t => t.ComplianceFormID, cascadeDelete: true)
                .Index(t => t.ComplianceFormID);
            
            CreateTable(
                "dbo.ComplianceForms",
                c => new
                    {
                        ComplianceFormID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ComplianceCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ComplianceFormID)
                .ForeignKey("dbo.ComplianceCategories", t => t.ComplianceCategoryID)
                .Index(t => t.ComplianceCategoryID);
            
            CreateTable(
                "dbo.ComplianceCategories",
                c => new
                    {
                        ComplianceCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ProductID = c.Int(),
                        ProdAdmin_ProductListingID = c.Int(),
                    })
                .PrimaryKey(t => t.ComplianceCategoryID)
                .ForeignKey("dbo.Products", t => t.ProdAdmin_ProductListingID)
                .Index(t => t.ProdAdmin_ProductListingID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductListingID = c.Int(nullable: false, identity: true),
                        AddedDate = c.DateTime(nullable: false),
                        ProductName = c.String(nullable: false),
                        Source = c.String(),
                        ComplianceForm_ComplianceFormID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductListingID)
                .ForeignKey("dbo.ComplianceForms", t => t.ComplianceForm_ComplianceFormID)
                .Index(t => t.ComplianceForm_ComplianceFormID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ComplianceForm_ComplianceFormID", "dbo.ComplianceForms");
            DropForeignKey("dbo.Compliances", "ComplianceFormID", "dbo.ComplianceForms");
            DropForeignKey("dbo.ComplianceCategories", "ProdAdmin_ProductListingID", "dbo.Products");
            DropForeignKey("dbo.ComplianceForms", "ComplianceCategoryID", "dbo.ComplianceCategories");
            DropIndex("dbo.Products", new[] { "ComplianceForm_ComplianceFormID" });
            DropIndex("dbo.ComplianceCategories", new[] { "ProdAdmin_ProductListingID" });
            DropIndex("dbo.ComplianceForms", new[] { "ComplianceCategoryID" });
            DropIndex("dbo.Compliances", new[] { "ComplianceFormID" });
            DropTable("dbo.Products");
            DropTable("dbo.ComplianceCategories");
            DropTable("dbo.ComplianceForms");
            DropTable("dbo.Compliances");
        }
    }
}
