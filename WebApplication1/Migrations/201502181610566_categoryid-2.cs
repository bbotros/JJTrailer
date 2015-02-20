namespace JJTrailerStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryid2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryImageID", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryImageID", c => c.Guid(nullable: false));
        }
    }
}
