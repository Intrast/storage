namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToMany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "ProfileId", c => c.Int());
            CreateIndex("dbo.Equipments", "ProfileId");
            AddForeignKey("dbo.Equipments", "ProfileId", "dbo.Profiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Equipments", new[] { "ProfileId" });
            DropColumn("dbo.Equipments", "ProfileId");
        }
    }
}
