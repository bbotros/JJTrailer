namespace JJTrailerStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initseed0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        MetaTagDescription = c.String(),
                        MetaTagKeywords = c.String(),
                        CategoryImageID = c.Guid(nullable: false),
                        CategoryID = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DimensionClasses",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ImageManagers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Path = c.String(),
                        MetaTagDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        MetaTagDescription = c.String(),
                        MetaTagKeywords = c.String(),
                        ManufacturerImageID = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        InvoiceID = c.String(),
                        ShoppingCartID = c.Guid(nullable: false),
                        PaymentID = c.Guid(nullable: false),
                        ShippingID = c.Guid(nullable: false),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        IPAddress = c.String(),
                        UserBrowser = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OutOfStockStatus",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PaymentMethodID = c.Guid(nullable: false),
                        PaymentTransactionID = c.Guid(nullable: false),
                        isPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        MetaTagDescription = c.String(),
                        MetaTagKeywords = c.String(),
                        ProductImageID = c.Guid(nullable: false),
                        Model = c.String(),
                        SKU = c.String(),
                        ShopID = c.Guid(nullable: false),
                        TaxClassID = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumQuantity = c.Int(nullable: false),
                        SubtractStock = c.Boolean(nullable: false),
                        OutOfStockStatusID = c.Guid(nullable: false),
                        InStoreOnly = c.Boolean(nullable: false),
                        DimensionID = c.Guid(nullable: false),
                        Weight = c.Single(nullable: false),
                        WeightClassID = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CategoryID = c.Guid(nullable: false),
                        ManufacturerID = c.Guid(nullable: false),
                        RelatedProductID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShippingMethods",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Shippings",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ShippingMethodID = c.Guid(nullable: false),
                        ShippingPickupDate = c.DateTime(nullable: false),
                        isShipped = c.Boolean(nullable: false),
                        isArrived = c.Boolean(nullable: false),
                        ActualArrivalDate = c.DateTime(nullable: false),
                        EstimatedArrivalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TaxClasses",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Percentage = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WeightClasses",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeightClasses");
            DropTable("dbo.Taxes");
            DropTable("dbo.TaxClasses");
            DropTable("dbo.Shops");
            DropTable("dbo.Shippings");
            DropTable("dbo.ShippingMethods");
            DropTable("dbo.Products");
            DropTable("dbo.Payments");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.OutOfStockStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.ImageManagers");
            DropTable("dbo.DimensionClasses");
            DropTable("dbo.Categories");
        }
    }
}
