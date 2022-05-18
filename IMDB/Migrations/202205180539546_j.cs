namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavouriteActors", "Actor_ID_Actor_ID", "dbo.Actors");
            DropForeignKey("dbo.FavouriteActors", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.FavouriteDirectors", "Director_ID_Director_ID", "dbo.Directors");
            DropForeignKey("dbo.FavouriteDirectors", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.FavouriteMovies", "Movie_ID_Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.FavouriteMovies", "User_ID_User_ID", "dbo.Users");
            DropIndex("dbo.FavouriteActors", new[] { "Actor_ID_Actor_ID" });
            DropIndex("dbo.FavouriteActors", new[] { "User_ID_User_ID" });
            DropIndex("dbo.FavouriteDirectors", new[] { "Director_ID_Director_ID" });
            DropIndex("dbo.FavouriteDirectors", new[] { "User_ID_User_ID" });
            DropIndex("dbo.FavouriteMovies", new[] { "Movie_ID_Movie_ID" });
            DropIndex("dbo.FavouriteMovies", new[] { "User_ID_User_ID" });
            RenameColumn(table: "dbo.FavouriteActors", name: "Actor_ID_Actor_ID", newName: "Actor_ID");
            RenameColumn(table: "dbo.FavouriteActors", name: "User_ID_User_ID", newName: "User_ID");
            RenameColumn(table: "dbo.FavouriteDirectors", name: "Director_ID_Director_ID", newName: "Director_ID");
            RenameColumn(table: "dbo.FavouriteDirectors", name: "User_ID_User_ID", newName: "User_ID");
            RenameColumn(table: "dbo.FavouriteMovies", name: "Movie_ID_Movie_ID", newName: "Movie_ID");
            RenameColumn(table: "dbo.FavouriteMovies", name: "User_ID_User_ID", newName: "User_ID");
            AddColumn("dbo.Actors", "ImgPath", c => c.String());
            AddColumn("dbo.MovieActors", "ID", c => c.Int(nullable: false));
            AddColumn("dbo.Likes", "Like_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Likes", "like", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FavouriteActors", "Actor_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.FavouriteActors", "User_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.FavouriteDirectors", "Director_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.FavouriteDirectors", "User_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.FavouriteMovies", "Movie_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.FavouriteMovies", "User_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.FavouriteActors", "User_ID");
            CreateIndex("dbo.FavouriteActors", "Actor_ID");
            CreateIndex("dbo.FavouriteDirectors", "User_ID");
            CreateIndex("dbo.FavouriteDirectors", "Director_ID");
            CreateIndex("dbo.FavouriteMovies", "User_ID");
            CreateIndex("dbo.FavouriteMovies", "Movie_ID");
            AddForeignKey("dbo.FavouriteActors", "Actor_ID", "dbo.Actors", "Actor_ID", cascadeDelete: true);
            AddForeignKey("dbo.FavouriteActors", "User_ID", "dbo.Users", "User_ID", cascadeDelete: true);
            AddForeignKey("dbo.FavouriteDirectors", "Director_ID", "dbo.Directors", "Director_ID", cascadeDelete: true);
            AddForeignKey("dbo.FavouriteDirectors", "User_ID", "dbo.Users", "User_ID", cascadeDelete: true);
            AddForeignKey("dbo.FavouriteMovies", "Movie_ID", "dbo.Movies", "Movie_ID", cascadeDelete: true);
            AddForeignKey("dbo.FavouriteMovies", "User_ID", "dbo.Users", "User_ID", cascadeDelete: true);
            DropColumn("dbo.Actors", "Img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actors", "Img", c => c.String());
            DropForeignKey("dbo.FavouriteMovies", "User_ID", "dbo.Users");
            DropForeignKey("dbo.FavouriteMovies", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.FavouriteDirectors", "User_ID", "dbo.Users");
            DropForeignKey("dbo.FavouriteDirectors", "Director_ID", "dbo.Directors");
            DropForeignKey("dbo.FavouriteActors", "User_ID", "dbo.Users");
            DropForeignKey("dbo.FavouriteActors", "Actor_ID", "dbo.Actors");
            DropIndex("dbo.FavouriteMovies", new[] { "Movie_ID" });
            DropIndex("dbo.FavouriteMovies", new[] { "User_ID" });
            DropIndex("dbo.FavouriteDirectors", new[] { "Director_ID" });
            DropIndex("dbo.FavouriteDirectors", new[] { "User_ID" });
            DropIndex("dbo.FavouriteActors", new[] { "Actor_ID" });
            DropIndex("dbo.FavouriteActors", new[] { "User_ID" });
            AlterColumn("dbo.FavouriteMovies", "User_ID", c => c.Int());
            AlterColumn("dbo.FavouriteMovies", "Movie_ID", c => c.Int());
            AlterColumn("dbo.FavouriteDirectors", "User_ID", c => c.Int());
            AlterColumn("dbo.FavouriteDirectors", "Director_ID", c => c.Int());
            AlterColumn("dbo.FavouriteActors", "User_ID", c => c.Int());
            AlterColumn("dbo.FavouriteActors", "Actor_ID", c => c.Int());
            AlterColumn("dbo.Likes", "like", c => c.Int(nullable: false));
            DropColumn("dbo.Likes", "Like_ID");
            DropColumn("dbo.MovieActors", "ID");
            DropColumn("dbo.Actors", "ImgPath");
            RenameColumn(table: "dbo.FavouriteMovies", name: "User_ID", newName: "User_ID_User_ID");
            RenameColumn(table: "dbo.FavouriteMovies", name: "Movie_ID", newName: "Movie_ID_Movie_ID");
            RenameColumn(table: "dbo.FavouriteDirectors", name: "User_ID", newName: "User_ID_User_ID");
            RenameColumn(table: "dbo.FavouriteDirectors", name: "Director_ID", newName: "Director_ID_Director_ID");
            RenameColumn(table: "dbo.FavouriteActors", name: "User_ID", newName: "User_ID_User_ID");
            RenameColumn(table: "dbo.FavouriteActors", name: "Actor_ID", newName: "Actor_ID_Actor_ID");
            CreateIndex("dbo.FavouriteMovies", "User_ID_User_ID");
            CreateIndex("dbo.FavouriteMovies", "Movie_ID_Movie_ID");
            CreateIndex("dbo.FavouriteDirectors", "User_ID_User_ID");
            CreateIndex("dbo.FavouriteDirectors", "Director_ID_Director_ID");
            CreateIndex("dbo.FavouriteActors", "User_ID_User_ID");
            CreateIndex("dbo.FavouriteActors", "Actor_ID_Actor_ID");
            AddForeignKey("dbo.FavouriteMovies", "User_ID_User_ID", "dbo.Users", "User_ID");
            AddForeignKey("dbo.FavouriteMovies", "Movie_ID_Movie_ID", "dbo.Movies", "Movie_ID");
            AddForeignKey("dbo.FavouriteDirectors", "User_ID_User_ID", "dbo.Users", "User_ID");
            AddForeignKey("dbo.FavouriteDirectors", "Director_ID_Director_ID", "dbo.Directors", "Director_ID");
            AddForeignKey("dbo.FavouriteActors", "User_ID_User_ID", "dbo.Users", "User_ID");
            AddForeignKey("dbo.FavouriteActors", "Actor_ID_Actor_ID", "dbo.Actors", "Actor_ID");
        }
    }
}
