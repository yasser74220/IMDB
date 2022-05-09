namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmEmail", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ConfirmEmail");
        }
    }
}
