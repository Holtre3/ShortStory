namespace ShortStoryReviewSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "StoryContent", c => c.String(nullable: false));
            AlterColumn("dbo.Stories", "Author", c => c.String(nullable: false));
            DropColumn("dbo.Stories", "FilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stories", "FilePath", c => c.String(nullable: false));
            AlterColumn("dbo.Stories", "Author", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Stories", "StoryContent");
        }
    }
}
