namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Fname", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "Lname", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "Image", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Passward", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "Img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Img", c => c.Binary());
            AlterColumn("dbo.Users", "Passward", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "Image");
            DropColumn("dbo.Users", "Lname");
            DropColumn("dbo.Users", "Fname");
        }
    }
}
