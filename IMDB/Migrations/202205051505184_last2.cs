namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "Passward");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Passward", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "Password");
        }
    }
}
