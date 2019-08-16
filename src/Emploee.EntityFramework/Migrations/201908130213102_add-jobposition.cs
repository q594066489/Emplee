namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobposition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Job_Position",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position_no = c.Short(nullable: false),
                        Position_name = c.String(maxLength: 200),
                        Parent_id = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Job_Position");
        }
    }
}
