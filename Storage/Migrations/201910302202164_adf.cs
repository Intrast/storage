namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserId", c => c.String());
            DropColumn("dbo.Orders", "ProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProfileId", c => c.String());
            DropColumn("dbo.Orders", "UserId");
        }
    }
}
