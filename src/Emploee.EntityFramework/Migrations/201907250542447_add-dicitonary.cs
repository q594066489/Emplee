namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddicitonary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dictionary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentCode = c.String(maxLength: 4000),
                        Code = c.String(nullable: false, maxLength: 4000),
                        Name = c.String(nullable: false, maxLength: 4000),
                        OrderIndex = c.Int(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dictionary");
        }
    }
}
