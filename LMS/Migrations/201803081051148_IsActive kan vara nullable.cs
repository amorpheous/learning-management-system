namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActivekanvaranullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
