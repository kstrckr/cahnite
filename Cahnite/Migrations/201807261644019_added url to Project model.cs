namespace Cahnite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedurltoProjectmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Url", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Url");
        }
    }
}
