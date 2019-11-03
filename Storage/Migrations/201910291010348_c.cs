namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Notation", c => c.String());
            CreateIndex("dbo.Orders", "EquipmentId");
            AddForeignKey("dbo.Orders", "EquipmentId", "dbo.Equipments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.Orders", new[] { "EquipmentId" });
            DropColumn("dbo.Orders", "Notation");
        }
    }
}
