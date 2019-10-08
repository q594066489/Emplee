namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Memo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPost", "Memo", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPost", "Memo");
        }
    }
}
