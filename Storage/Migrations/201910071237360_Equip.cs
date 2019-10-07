namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Equip : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipments", "Name", c => c.Int(nullable: false));
        }
    }
}
