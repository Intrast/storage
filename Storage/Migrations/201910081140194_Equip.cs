namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Equip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "Categories", c => c.String());
            AddColumn("dbo.Equipments", "DateOfPurchase", c => c.DateTime(nullable: false));
            AddColumn("dbo.Equipments", "Notes", c => c.String());
            AlterColumn("dbo.Equipments", "Key", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipments", "Key", c => c.Int(nullable: false));
            DropColumn("dbo.Equipments", "Notes");
            DropColumn("dbo.Equipments", "DateOfPurchase");
            DropColumn("dbo.Equipments", "Categories");
        }
    }
}
