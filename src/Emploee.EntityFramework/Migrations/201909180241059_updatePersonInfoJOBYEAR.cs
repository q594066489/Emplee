namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePersonInfoJOBYEAR : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonInfo", "JobYear", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonInfo", "JobYear", c => c.Int(nullable: false));
        }
    }
}
