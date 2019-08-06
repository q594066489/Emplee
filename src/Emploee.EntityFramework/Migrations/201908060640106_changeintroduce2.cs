namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeintroduce2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "CompanyIntroduce", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "CompanyIntroduce", c => c.String(maxLength: 200));
        }
    }
}
