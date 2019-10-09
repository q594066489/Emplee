namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_PostDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobPerson", "PostDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobPerson", "PostDate", c => c.Int(nullable: false));
        }
    }
}
