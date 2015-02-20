namespace JJTrailerStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryImages",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CategoryID = c.Guid(nullable: false),
                        ImageManagerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Categories", "CategoryID", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryID", c => c.Guid(nullable: false));
            DropTable("dbo.CategoryImages");
        }
    }
}
