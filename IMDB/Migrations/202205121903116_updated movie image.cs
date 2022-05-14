namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmovieimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ImgPath", c => c.String());
            DropColumn("dbo.Movies", "img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "img", c => c.String());
            DropColumn("dbo.Movies", "ImgPath");
        }
    }
}
