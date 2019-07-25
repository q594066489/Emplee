namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addadvertise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Advertiser = c.String(maxLength: 200),
                        AdverPicture = c.String(maxLength: 4000),
                        AdverAddress = c.String(maxLength: 400),
                        PayAmount = c.String(maxLength: 4000),
                        PayTime = c.DateTime(nullable: false),
                        CoopTime = c.Int(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Advertisement");
        }
    }
}
