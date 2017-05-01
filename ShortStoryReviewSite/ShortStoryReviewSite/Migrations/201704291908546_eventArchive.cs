namespace ShortStoryReviewSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventArchive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Archived", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Message", c => c.String());
            AlterColumn("dbo.Events", "Name", c => c.String());
            DropColumn("dbo.Events", "Archived");
        }
    }
}
