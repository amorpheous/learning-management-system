namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedandroles : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Course_Id", newName: "Course__Id");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Course_Id", newName: "IX_Course__Id");
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "NickName", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AdditionalInfo", c => c.String());
            AddColumn("dbo.AspNetUsers", "SpecialInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SpecialInfo");
            DropColumn("dbo.AspNetUsers", "AdditionalInfo");
            DropColumn("dbo.AspNetUsers", "IsActive");
            DropColumn("dbo.AspNetUsers", "NickName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "UserId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Course__Id", newName: "IX_Course_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "Course__Id", newName: "Course_Id");
        }
    }
}
