namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addapproval : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Approval",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsPay = c.Boolean(nullable: false),
                        PayAmount = c.Double(),
                        PayTime = c.DateTime(),
                        CoopTime = c.Int(),
                        Weight = c.Int(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Approval");
        }
    }
}
