namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcompanyidandpersonid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "CompanyID", c => c.Long(nullable: false));
            AddColumn("dbo.PersonInfo", "PersonID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonInfo", "PersonID");
            DropColumn("dbo.Company", "CompanyID");
        }
    }
}
