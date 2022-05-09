namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleterole : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Role_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role_ID", c => c.Int(nullable: false));
        }
    }
}
