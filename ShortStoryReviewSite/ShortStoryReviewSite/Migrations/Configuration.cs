namespace ShortStoryReviewSite.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShortStoryReviewSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShortStoryReviewSite.Models.ApplicationDbContext context)
        {
            //context.Stories.AddOrUpdate(
            //    s => s.Title,
            //    new Story
            //    {
            //        Id = 1,
            //        Title = "Writing1",
            //        Author = "Jason",
            //        Genre = StoryGenre.Comedy,
            //        StoryContent = @"~/Content/Texts/Writing1.txt",
            //        Score = 0,
            //        SubmissionDate = Convert.ToDateTime("1/1/1")
            //    },
            //    new Story
            //    {
            //        Id = 2,
            //        Title = "Writing2",
            //        Author = "Jason",
            //        Genre = StoryGenre.Comedy,
            //        StoryContent = @"~/Content/Texts/Writing2.txt",
            //        Score = 0,
            //        SubmissionDate = Convert.ToDateTime("2/2/2")
            //    },
            //    new Story
            //    {
            //        Id = 3,
            //        Title = "Writing3",
            //        Author = "Jason",
            //        Genre = StoryGenre.Comedy,
            //        StoryContent = @"~/Content/Texts/Writing3.txt",
            //        Score = 0,
            //        SubmissionDate = Convert.ToDateTime("3/3/3")
            //    },
            //    new Story
            //    {
            //        Id = 4,
            //        Title = "Writing4",
            //        Author = "Jason",
            //        Genre = StoryGenre.Comedy,
            //        StoryContent = @"~/Content/Texts/Writing4.txt",
            //        Score = 0,
            //        SubmissionDate = Convert.ToDateTime("4/4/4")
            //    }
            //    );
            //context.Reviews.AddOrUpdate(
            //    r => r.Id,
            //    new Review()
            //    {
            //        Id = 1,
            //        StoryId = 1,
            //        UserName = "Jason",
            //        Score = 1,
            //        ReviewDate = Convert.ToDateTime("1/1/1"),
            //        ReviewText =
            //        @"
            //            Really good. Great words.
            //         "
            //    },
            //    new Review()
            //    {
            //        Id = 2,
            //        StoryId = 2,
            //        UserName = "Carl",
            //        Score = 2,
            //        ReviewDate = Convert.ToDateTime("2/2/2"),
            //        ReviewText =
            //        @"
            //            Really bad. Terrible words.
            //         "
            //    },
            //    new Review()
            //    {
            //        Id = 3,
            //        StoryId = 3,
            //        UserName = "Abe",
            //        Score = 3,
            //        ReviewDate = Convert.ToDateTime("3/3/3"),
            //        ReviewText =
            //        @"
            //            It was okay. Mediocre words.
            //         "
            //    },
            //    new Review()
            //    {
            //        Id = 4,
            //        StoryId = 4,
            //        UserName = "Bill",
            //        Score = 4,
            //        ReviewDate = Convert.ToDateTime("4/4/4"),
            //        ReviewText =
            //        @"
            //            WHAT A MASTERPIECE!!!
            //         "
            //    }
            //    );
        }
    }
}
