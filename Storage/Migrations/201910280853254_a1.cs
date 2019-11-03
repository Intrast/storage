namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Orders", new[] { "ProfileId" });
            AddColumn("dbo.Orders", "Profile_Id", c => c.Int());
            AlterColumn("dbo.Orders", "ProfileId", c => c.String());
            CreateIndex("dbo.Orders", "Profile_Id");
            AddForeignKey("dbo.Orders", "Profile_Id", "dbo.Profiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Orders", new[] { "Profile_Id" });
            AlterColumn("dbo.Orders", "ProfileId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Profile_Id");
            CreateIndex("dbo.Orders", "ProfileId");
            AddForeignKey("dbo.Orders", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
        }
    }
}
