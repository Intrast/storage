namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.Profiles", "ProfileGroup_Id", c => c.Int());
            CreateIndex("dbo.Profiles", "ProfileGroup_Id");
            AddForeignKey("dbo.Profiles", "ProfileGroup_Id", "dbo.ProfileGroups", "Id");
            DropColumn("dbo.Profiles", "Group");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Group", c => c.String());
            DropForeignKey("dbo.Profiles", "ProfileGroup_Id", "dbo.ProfileGroups");
            DropIndex("dbo.Profiles", new[] { "ProfileGroup_Id" });
            DropColumn("dbo.Profiles", "ProfileGroup_Id");
            DropColumn("dbo.Profiles", "GroupId");
        }
    }
}
