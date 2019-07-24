namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjoburgent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobUrgent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        UrgentType = c.String(maxLength: 200),
                        UrgentDate = c.DateTime(),
                        UrgentLength = c.Int(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobUrgent");
        }
    }
}
