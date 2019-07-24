namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJobPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        JobName = c.String(nullable: false, maxLength: 200),
                        SalaryMin = c.Int(nullable: false),
                        SalaryMax = c.Int(nullable: false),
                        Education = c.String(maxLength: 200),
                        Experience = c.String(maxLength: 200),
                        JobAddress = c.String(maxLength: 400),
                        SkillRequire = c.String(maxLength: 4000),
                        JobDetail = c.String(maxLength: 4000),
                        JobSelect = c.String(maxLength: 200),
                        JobType = c.String(maxLength: 200),
                        PublishDate = c.DateTime(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobPost");
        }
    }
}
