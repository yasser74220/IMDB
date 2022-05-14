namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataAnnotationsandmodelprops : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Actors", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Actors", "Img", c => c.String());
            AlterColumn("dbo.Comments", "comment", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Movies", "Movie_Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Movies", "img", c => c.String());
            AlterColumn("dbo.Directors", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Directors", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Directors", "LastName", c => c.String());
            AlterColumn("dbo.Directors", "FirstName", c => c.String());
            AlterColumn("dbo.Movies", "img", c => c.Binary());
            AlterColumn("dbo.Movies", "Movie_Name", c => c.String());
            AlterColumn("dbo.Comments", "comment", c => c.String());
            AlterColumn("dbo.Actors", "Img", c => c.Binary());
            AlterColumn("dbo.Actors", "LastName", c => c.String());
            AlterColumn("dbo.Actors", "FirstName", c => c.String());
        }
    }
}
