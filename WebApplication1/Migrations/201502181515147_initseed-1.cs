namespace JJTrailerStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initseed1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Description", c => c.String());
            AddColumn("dbo.Manufacturers", "Description", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Manufacturers", "Description");
            DropColumn("dbo.Categories", "Description");
        }
    }
}
