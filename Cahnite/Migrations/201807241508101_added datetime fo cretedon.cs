namespace Cahnite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddatetimefocretedon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "CreatedOn");
        }
    }
}
