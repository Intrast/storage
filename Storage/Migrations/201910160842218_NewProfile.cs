namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audits", "NewStatus_Id", c => c.Int());
            AddColumn("dbo.Audits", "OldStatus_Id", c => c.Int());
            CreateIndex("dbo.Audits", "NewStatus_Id");
            CreateIndex("dbo.Audits", "OldStatus_Id");
            AddForeignKey("dbo.Audits", "NewStatus_Id", "dbo.AuditStatus", "Id");
            AddForeignKey("dbo.Audits", "OldStatus_Id", "dbo.AuditStatus", "Id");
            DropColumn("dbo.Audits", "NewStatus");
            DropColumn("dbo.Audits", "OldStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Audits", "OldStatus", c => c.String());
            AddColumn("dbo.Audits", "NewStatus", c => c.String());
            DropForeignKey("dbo.Audits", "OldStatus_Id", "dbo.AuditStatus");
            DropForeignKey("dbo.Audits", "NewStatus_Id", "dbo.AuditStatus");
            DropIndex("dbo.Audits", new[] { "OldStatus_Id" });
            DropIndex("dbo.Audits", new[] { "NewStatus_Id" });
            DropColumn("dbo.Audits", "OldStatus_Id");
            DropColumn("dbo.Audits", "NewStatus_Id");
        }
    }
}
