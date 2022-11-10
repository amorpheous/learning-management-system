namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Activities", "CreationTime");
            DropColumn("dbo.ActivityTypes", "CreationTime");
            DropColumn("dbo.Modules", "CreationTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modules", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ActivityTypes", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Activities", "CreationTime", c => c.DateTime(nullable: false));
        }
    }
}
