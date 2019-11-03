namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "Profile_Id", newName: "ProfileId");
            RenameIndex(table: "dbo.Orders", name: "IX_Profile_Id", newName: "IX_ProfileId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_ProfileId", newName: "IX_Profile_Id");
            RenameColumn(table: "dbo.Orders", name: "ProfileId", newName: "Profile_Id");
        }
    }
}
