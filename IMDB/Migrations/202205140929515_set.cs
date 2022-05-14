namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class set : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Actor_ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        Img = c.String(),
                    })
                .PrimaryKey(t => t.Actor_ID);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Actor_ID = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_ID, t.Movie_ID })
                .ForeignKey("dbo.Actors", t => t.Actor_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .Index(t => t.Actor_ID)
                .Index(t => t.Movie_ID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Movie_ID = c.Int(nullable: false, identity: true),
                        Director_ID = c.Int(nullable: false),
                        Movie_Name = c.String(nullable: false, maxLength: 200),
                        ImgPath = c.String(),
                    })
                .PrimaryKey(t => t.Movie_ID)
                .ForeignKey("dbo.Directors", t => t.Director_ID, cascadeDelete: true)
                .Index(t => t.Director_ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Comment_ID = c.Int(nullable: false, identity: true),
                        User_ID = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                        comment = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Comment_ID)
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID)
                .Index(t => t.Movie_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_ID = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false, maxLength: 50),
                        Lname = c.String(nullable: false, maxLength: 50),
                        Image = c.String(),
                        Email = c.String(nullable: false, maxLength: 50),
                        ConfirmEmail = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        ConfirmPassword = c.String(nullable: false, maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.User_ID);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Director_ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Director_ID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Movie_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                        like = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_ID, t.User_ID })
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.Movie_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.FavouriteActors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Actor_ID_Actor_ID = c.Int(),
                        User_ID_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actors", t => t.Actor_ID_Actor_ID)
                .ForeignKey("dbo.Users", t => t.User_ID_User_ID)
                .Index(t => t.Actor_ID_Actor_ID)
                .Index(t => t.User_ID_User_ID);
            
            CreateTable(
                "dbo.FavouriteDirectors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Director_ID_Director_ID = c.Int(),
                        User_ID_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Directors", t => t.Director_ID_Director_ID)
                .ForeignKey("dbo.Users", t => t.User_ID_User_ID)
                .Index(t => t.Director_ID_Director_ID)
                .Index(t => t.User_ID_User_ID);
            
            CreateTable(
                "dbo.FavouriteMovies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Movie_ID_Movie_ID = c.Int(),
                        User_ID_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.Movie_ID_Movie_ID)
                .ForeignKey("dbo.Users", t => t.User_ID_User_ID)
                .Index(t => t.Movie_ID_Movie_ID)
                .Index(t => t.User_ID_User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavouriteMovies", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.FavouriteMovies", "Movie_ID_Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.FavouriteDirectors", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.FavouriteDirectors", "Director_ID_Director_ID", "dbo.Directors");
            DropForeignKey("dbo.FavouriteActors", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.FavouriteActors", "Actor_ID_Actor_ID", "dbo.Actors");
            DropForeignKey("dbo.Likes", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Likes", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "Director_ID", "dbo.Directors");
            DropForeignKey("dbo.Comments", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "Actor_ID", "dbo.Actors");
            DropIndex("dbo.FavouriteMovies", new[] { "User_ID_User_ID" });
            DropIndex("dbo.FavouriteMovies", new[] { "Movie_ID_Movie_ID" });
            DropIndex("dbo.FavouriteDirectors", new[] { "User_ID_User_ID" });
            DropIndex("dbo.FavouriteDirectors", new[] { "Director_ID_Director_ID" });
            DropIndex("dbo.FavouriteActors", new[] { "User_ID_User_ID" });
            DropIndex("dbo.FavouriteActors", new[] { "Actor_ID_Actor_ID" });
            DropIndex("dbo.Likes", new[] { "User_ID" });
            DropIndex("dbo.Likes", new[] { "Movie_ID" });
            DropIndex("dbo.Comments", new[] { "Movie_ID" });
            DropIndex("dbo.Comments", new[] { "User_ID" });
            DropIndex("dbo.Movies", new[] { "Director_ID" });
            DropIndex("dbo.MovieActors", new[] { "Movie_ID" });
            DropIndex("dbo.MovieActors", new[] { "Actor_ID" });
            DropTable("dbo.FavouriteMovies");
            DropTable("dbo.FavouriteDirectors");
            DropTable("dbo.FavouriteActors");
            DropTable("dbo.Likes");
            DropTable("dbo.Directors");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Movies");
            DropTable("dbo.MovieActors");
            DropTable("dbo.Actors");
        }
    }
}
