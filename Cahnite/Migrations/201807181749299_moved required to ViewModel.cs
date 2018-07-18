namespace Cahnite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movedrequiredtoViewModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String());
            AlterColumn("dbo.Projects", "Intro", c => c.String());
            AlterColumn("dbo.Projects", "BodyHtml", c => c.String());
            AlterColumn("dbo.Projects", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "BodyHtml", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Intro", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
        }
    }
}
