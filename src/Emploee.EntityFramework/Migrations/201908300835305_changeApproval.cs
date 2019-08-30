namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeApproval : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Approval", "IsShow", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Approval", "IsShow");
        }
    }
}
