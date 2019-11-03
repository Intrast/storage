namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "DateStartWork", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "DateStartWork", c => c.DateTime(nullable: false));
        }
    }
}
