namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Profiles", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Profiles", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Profiles", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Profiles", name: "UserId", newName: "User_Id");
        }
    }
}
