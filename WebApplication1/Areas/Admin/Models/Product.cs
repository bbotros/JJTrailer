using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class Product
    {
        //general
        public Guid ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Html)]
        public string Description { get; set; }
        public string MetaTagDescription { get; set; }
        public string MetaTagKeywords { get; set; }
        //data
        public Guid ProductImageID { get; set; }
        public string Model { get; set; }
        public string SKU { get; set; }
        public Guid ShopID { get; set; }
        public Guid TaxClassID { get; set; }
        public int Quantity { get;set; }
        public decimal Price { get; set; }

        public int MinimumQuantity { get; set; }
        public bool SubtractStock { get; set; }
        public Guid OutOfStockStatusID { get; set; }
        public bool InStoreOnly { get; set; }
        public Guid DimensionID { get; set; }
        public float Weight { get; set; }
        public Guid  WeightClassID { get; set; }
        public bool Status { get; set; }

        //Links
        public Guid CategoryID { get; set; }
        public Guid ManufacturerID { get; set; }
        public Guid RelatedProductID{get;set;}
    }
}