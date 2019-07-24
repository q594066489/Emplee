namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobperson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPerson",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        JobID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        PostDate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobPerson");
        }
    }
}
