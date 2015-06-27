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
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string Source { get; set; }
        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }
        public string Group { get; set; }
        [Display(Name = "ABC Class")]
        public string ABCClass { get; set; }
        public string Status { get; set; }
        public string ControlCode { get; set; }
        public string Cond { get; set; }
        public string Indicator { get; set; }
        public string CyclicCode { get; set; }
        public string UserGroup { get; set; }
        public string UserGroup1 { get; set; }
        public string ItemDescription { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Unit { get; set; }
        public int Weight { get; set; }
        public string Pack { get; set; }
        public int PackQty { get; set; }
        public int Volume { get; set; }
        public int ConversionFactor { get; set; }
        public string AltUnitDesc { get; set; }
        public string ItemGTIN { get; set; }
        public string ModVAT { get; set; }
        public string Trace { get; set; }
        public string Storage { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ReplacementCost { get; set; }
        public string SalesCost { get; set; }
        public string DutyPaidCost { get; set; }
        public string InfoCost { get; set; }
        public string ShelfLifeDays { get; set; }
        public string WarrantyTypeFlag { get; set; }
        public string DateLastChange { get; set; }
        public string Per { get; set; }
        public string ReorderPolicy { get; set; }
        public string ReorderReview { get; set; }
        public string ReorderBuyer { get; set; }
        public string CreationDate { get; set; }
        public string MovementCode { get; set; }
        public string SalesType { get; set; }
        public string SalesTaxPaidRate { get; set; }
        public string SortCode { get; set; }
        public string ExciseQty { get; set; }
        public string UnSpscCode { get; set; }
        public string AnalysisCode1 { get; set; }
        public string AnalysisCode2 { get; set; }
        public string AnalysisCode3 { get; set; }
        public string SpareAnalysisCode { get; set; }
        public string stkTallyCode { get; set; }
        public string Brand { get; set; }
        public string OriginFlag { get; set; }
        public string OriginSource { get; set; }
        public string PriceProtection { get; set; }
        public string StkSpare1 { get; set; }
        public string StkSpare2 { get; set; }
        public string StkUserOnlyDate1 { get; set; }
        public string StkUserOnlyDate2 { get; set; }
        public string StkUserOnlyAlpha201 { get; set; }
        public string StkUserOnlyAlpha202 { get; set; }
        public string StkUserOnlyAlpha41 { get; set; }
        public string StkUserOnlyAlpha42 { get; set; }
        public string StkUserOnlyAlpha43 { get; set; }
        public string StkUserOnlyAlpha44 { get; set; }
        public int StkUserOnlyNum1 { get; set; }
        public int StkUserOnlyNum2 { get; set; }
        public int StkUserOnlyNum3 { get; set; }
        public int StkUserOnlyNum4 { get; set; }
        public virtual ICollection<ComplianceForm> ComplianceForms { get; set; }



    }
}