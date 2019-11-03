namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "GroupId", "dbo.ProfileGroups");
            DropIndex("dbo.Profiles", new[] { "GroupId" });
            AlterColumn("dbo.Profiles", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Profiles", "GroupId");
            AddForeignKey("dbo.Profiles", "GroupId", "dbo.ProfileGroups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "GroupId", "dbo.ProfileGroups");
            DropIndex("dbo.Profiles", new[] { "GroupId" });
            AlterColumn("dbo.Profiles", "GroupId", c => c.Int());
            CreateIndex("dbo.Profiles", "GroupId");
            AddForeignKey("dbo.Profiles", "GroupId", "dbo.ProfileGroups", "Id");
        }
    }
}
