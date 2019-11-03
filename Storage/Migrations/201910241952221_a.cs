namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Profiles", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "UserId", c => c.Int(nullable: false));
        }
    }
}
