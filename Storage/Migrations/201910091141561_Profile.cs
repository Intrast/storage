namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Group", c => c.String());
            AddColumn("dbo.Profiles", "Tehnology", c => c.String());
            AddColumn("dbo.Profiles", "DateStartWork", c => c.DateTime(nullable: false));
            AddColumn("dbo.Profiles", "DateEndWork", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "DateEndWork");
            DropColumn("dbo.Profiles", "DateStartWork");
            DropColumn("dbo.Profiles", "Tehnology");
            DropColumn("dbo.Profiles", "Group");
        }
    }
}
