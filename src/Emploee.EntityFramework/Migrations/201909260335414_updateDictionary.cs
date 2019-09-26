namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDictionary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dictionary", "value", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dictionary", "value");
        }
    }
}
