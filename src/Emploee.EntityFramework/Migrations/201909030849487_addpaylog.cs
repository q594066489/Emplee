namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpaylog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PayLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        PayAmount = c.Double(nullable: false),
                        PayTime = c.DateTime(nullable: false),
                        CoopTime = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PayLog");
        }
    }
}
