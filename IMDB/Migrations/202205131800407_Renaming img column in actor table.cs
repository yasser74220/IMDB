namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renamingimgcolumninactortable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ImgPath", c => c.String());
            DropColumn("dbo.Actors", "Img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actors", "Img", c => c.String());
            DropColumn("dbo.Actors", "ImgPath");
        }
    }
}
