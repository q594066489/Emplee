namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateJobUrgentaddstate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobUrgent", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobUrgent", "State");
        }
    }
}
