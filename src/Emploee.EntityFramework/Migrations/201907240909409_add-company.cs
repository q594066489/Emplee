namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 200),
                        CompanyEmail = c.String(maxLength: 200),
                        CompanyPhone = c.String(maxLength: 15),
                        CompanyAddress = c.String(maxLength: 200),
                        CompanyScale = c.String(maxLength: 200),
                        CompanyIntroduce = c.String(maxLength: 200),
                        Classify = c.String(maxLength: 4000),
                        Finanicing = c.String(maxLength: 200),
                        BussinessLicense = c.String(maxLength: 4000),
                        RegisterDate = c.DateTime(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(maxLength: 256));
            DropColumn("dbo.AbpUsers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(nullable: false, maxLength: 256));
            DropTable("dbo.Company");
        }
    }
}
