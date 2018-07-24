namespace Cahnite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addededitedOnnullable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "EditedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "EditedOn");
        }
    }
}
