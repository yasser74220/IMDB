namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update227 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Director_ID_Director_ID", "dbo.Directors");
            DropForeignKey("dbo.Comments", "Movie_ID_Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Comments", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.Likes", "Movie_ID_Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Likes", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.MovieActors", "Actor_ID_Actor_ID", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "Movie_ID_Movie_ID", "dbo.Movies");
            DropIndex("dbo.Comments", new[] { "Movie_ID_Movie_ID" });
            DropIndex("dbo.Comments", new[] { "User_ID_User_ID" });
            DropIndex("dbo.Movies", new[] { "Director_ID_Director_ID" });
            DropIndex("dbo.Likes", new[] { "Movie_ID_Movie_ID" });
            DropIndex("dbo.Likes", new[] { "User_ID_User_ID" });
            DropIndex("dbo.MovieActors", new[] { "Actor_ID_Actor_ID" });
            DropIndex("dbo.MovieActors", new[] { "Movie_ID_Movie_ID" });
            RenameColumn(table: "dbo.Movies", name: "Director_ID_Director_ID", newName: "Director_ID");
            RenameColumn(table: "dbo.Comments", name: "Movie_ID_Movie_ID", newName: "Movie_ID");
            RenameColumn(table: "dbo.Comments", name: "User_ID_User_ID", newName: "User_ID");
            RenameColumn(table: "dbo.Likes", name: "Movie_ID_Movie_ID", newName: "Movie_ID");
            RenameColumn(table: "dbo.Likes", name: "User_ID_User_ID", newName: "User_ID");
            RenameColumn(table: "dbo.MovieActors", name: "Actor_ID_Actor_ID", newName: "Actor_ID");
            RenameColumn(table: "dbo.MovieActors", name: "Movie_ID_Movie_ID", newName: "Movie_ID");
            DropPrimaryKey("dbo.Likes");
            DropPrimaryKey("dbo.MovieActors");
            AddColumn("dbo.Movies", "ImgPath", c => c.String());
            AlterColumn("dbo.Actors", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Actors", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Actors", "Img", c => c.String());
            AlterColumn("dbo.Comments", "comment", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Comments", "Movie_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "User_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Movie_Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Movies", "Director_ID", c => c.Int(nullable: true));
            AlterColumn("dbo.Directors", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Directors", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Likes", "like", c => c.Int(nullable: false));
            AlterColumn("dbo.Likes", "Movie_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Likes", "User_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieActors", "Actor_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieActors", "Movie_ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Likes", new[] { "Movie_ID", "User_ID" });
            AddPrimaryKey("dbo.MovieActors", new[] { "Actor_ID", "Movie_ID" });
            CreateIndex("dbo.MovieActors", "Actor_ID");
            CreateIndex("dbo.MovieActors", "Movie_ID");
            CreateIndex("dbo.Movies", "Director_ID");
            CreateIndex("dbo.Comments", "User_ID");
            CreateIndex("dbo.Comments", "Movie_ID");
            CreateIndex("dbo.Likes", "Movie_ID");
            CreateIndex("dbo.Likes", "User_ID");
            AddForeignKey("dbo.Movies", "Director_ID", "dbo.Directors", "Director_ID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "Movie_ID", "dbo.Movies", "Movie_ID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "User_ID", "dbo.Users", "User_ID", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "Movie_ID", "dbo.Movies", "Movie_ID", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "User_ID", "dbo.Users", "User_ID", cascadeDelete: true);
            AddForeignKey("dbo.MovieActors", "Actor_ID", "dbo.Actors", "Actor_ID", cascadeDelete: true);
            AddForeignKey("dbo.MovieActors", "Movie_ID", "dbo.Movies", "Movie_ID", cascadeDelete: true);
            DropColumn("dbo.Movies", "img");
            DropColumn("dbo.Likes", "Like_ID");
            DropColumn("dbo.MovieActors", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieActors", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Likes", "Like_ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Movies", "img", c => c.Binary());
            DropForeignKey("dbo.MovieActors", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "Actor_ID", "dbo.Actors");
            DropForeignKey("dbo.Likes", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Likes", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Comments", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "Director_ID", "dbo.Directors");
            DropIndex("dbo.Likes", new[] { "User_ID" });
            DropIndex("dbo.Likes", new[] { "Movie_ID" });
            DropIndex("dbo.Comments", new[] { "Movie_ID" });
            DropIndex("dbo.Comments", new[] { "User_ID" });
            DropIndex("dbo.Movies", new[] { "Director_ID" });
            DropIndex("dbo.MovieActors", new[] { "Movie_ID" });
            DropIndex("dbo.MovieActors", new[] { "Actor_ID" });
            DropPrimaryKey("dbo.MovieActors");
            DropPrimaryKey("dbo.Likes");
            AlterColumn("dbo.MovieActors", "Movie_ID", c => c.Int());
            AlterColumn("dbo.MovieActors", "Actor_ID", c => c.Int());
            AlterColumn("dbo.Likes", "User_ID", c => c.Int());
            AlterColumn("dbo.Likes", "Movie_ID", c => c.Int());
            AlterColumn("dbo.Likes", "like", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Directors", "LastName", c => c.String());
            AlterColumn("dbo.Directors", "FirstName", c => c.String());
            AlterColumn("dbo.Movies", "Director_ID", c => c.Int());
            AlterColumn("dbo.Movies", "Movie_Name", c => c.String());
            AlterColumn("dbo.Comments", "User_ID", c => c.Int());
            AlterColumn("dbo.Comments", "Movie_ID", c => c.Int());
            AlterColumn("dbo.Comments", "comment", c => c.String());
            AlterColumn("dbo.Actors", "Img", c => c.Binary());
            AlterColumn("dbo.Actors", "LastName", c => c.String());
            AlterColumn("dbo.Actors", "FirstName", c => c.String());
            DropColumn("dbo.Movies", "ImgPath");
            AddPrimaryKey("dbo.MovieActors", "ID");
            AddPrimaryKey("dbo.Likes", "Like_ID");
            RenameColumn(table: "dbo.MovieActors", name: "Movie_ID", newName: "Movie_ID_Movie_ID");
            RenameColumn(table: "dbo.MovieActors", name: "Actor_ID", newName: "Actor_ID_Actor_ID");
            RenameColumn(table: "dbo.Likes", name: "User_ID", newName: "User_ID_User_ID");
            RenameColumn(table: "dbo.Likes", name: "Movie_ID", newName: "Movie_ID_Movie_ID");
            RenameColumn(table: "dbo.Comments", name: "User_ID", newName: "User_ID_User_ID");
            RenameColumn(table: "dbo.Comments", name: "Movie_ID", newName: "Movie_ID_Movie_ID");
            RenameColumn(table: "dbo.Movies", name: "Director_ID", newName: "Director_ID_Director_ID");
            CreateIndex("dbo.MovieActors", "Movie_ID_Movie_ID");
            CreateIndex("dbo.MovieActors", "Actor_ID_Actor_ID");
            CreateIndex("dbo.Likes", "User_ID_User_ID");
            CreateIndex("dbo.Likes", "Movie_ID_Movie_ID");
            CreateIndex("dbo.Movies", "Director_ID_Director_ID");
            CreateIndex("dbo.Comments", "User_ID_User_ID");
            CreateIndex("dbo.Comments", "Movie_ID_Movie_ID");
            AddForeignKey("dbo.MovieActors", "Movie_ID_Movie_ID", "dbo.Movies", "Movie_ID");
            AddForeignKey("dbo.MovieActors", "Actor_ID_Actor_ID", "dbo.Actors", "Actor_ID");
            AddForeignKey("dbo.Likes", "User_ID_User_ID", "dbo.Users", "User_ID");
            AddForeignKey("dbo.Likes", "Movie_ID_Movie_ID", "dbo.Movies", "Movie_ID");
            AddForeignKey("dbo.Comments", "User_ID_User_ID", "dbo.Users", "User_ID");
            AddForeignKey("dbo.Comments", "Movie_ID_Movie_ID", "dbo.Movies", "Movie_ID");
            AddForeignKey("dbo.Movies", "Director_ID_Director_ID", "dbo.Directors", "Director_ID");
        }
    }
}
