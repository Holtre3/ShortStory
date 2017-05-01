namespace ShortStoryReviewSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeaturedStoryEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "FeaturedStory_Id", c => c.Int());
            CreateIndex("dbo.Events", "FeaturedStory_Id");
            AddForeignKey("dbo.Events", "FeaturedStory_Id", "dbo.Stories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "FeaturedStory_Id", "dbo.Stories");
            DropIndex("dbo.Events", new[] { "FeaturedStory_Id" });
            DropColumn("dbo.Events", "FeaturedStory_Id");
        }
    }
}
