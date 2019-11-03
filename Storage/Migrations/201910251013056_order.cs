namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Orders", new[] { "Profile_Id" });
            RenameColumn(table: "dbo.Orders", name: "Profile_Id", newName: "ProfileId");
            AddColumn("dbo.Orders", "EquipmentId", c => c.Int());
            AlterColumn("dbo.Orders", "ProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ProfileId");
            AddForeignKey("dbo.Orders", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "ProfieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProfieId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Orders", new[] { "ProfileId" });
            AlterColumn("dbo.Orders", "ProfileId", c => c.Int());
            DropColumn("dbo.Orders", "EquipmentId");
            RenameColumn(table: "dbo.Orders", name: "ProfileId", newName: "Profile_Id");
            CreateIndex("dbo.Orders", "Profile_Id");
            AddForeignKey("dbo.Orders", "Profile_Id", "dbo.Profiles", "Id");
        }
    }
}
