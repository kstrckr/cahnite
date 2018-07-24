namespace Cahnite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpublshed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Publish", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Publish");
        }
    }
}
