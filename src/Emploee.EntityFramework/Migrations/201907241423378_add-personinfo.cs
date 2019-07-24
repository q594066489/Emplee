namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpersoninfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Age = c.Int(),
                        Sex = c.String(maxLength: 4000),
                        Education = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 15),
                        Email = c.String(maxLength: 50),
                        ExpectPosition = c.String(maxLength: 200),
                        ExpectTrade = c.String(maxLength: 200),
                        Resume = c.String(maxLength: 4000),
                        isOnJob = c.Boolean(nullable: false),
                        State = c.String(maxLength: 4000),
                        JobYear = c.Int(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonInfo");
        }
    }
}
