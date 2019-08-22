namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_salary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobPost", "SalaryMin", c => c.Double(nullable: false));
            AlterColumn("dbo.JobPost", "SalaryMax", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobPost", "SalaryMax", c => c.Int(nullable: false));
            AlterColumn("dbo.JobPost", "SalaryMin", c => c.Int(nullable: false));
        }
    }
}
