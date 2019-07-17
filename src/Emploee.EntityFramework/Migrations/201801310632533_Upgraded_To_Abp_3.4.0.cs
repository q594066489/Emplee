namespace Emploee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_Abp_340 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUserClaims", "ClaimType", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String(maxLength: 32));
            AlterColumn("dbo.AbpUserAccounts", "EmailAddress", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUserAccounts", "EmailAddress", c => c.String());
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String());
            AlterColumn("dbo.AbpUserClaims", "ClaimType", c => c.String());
        }
    }
}
