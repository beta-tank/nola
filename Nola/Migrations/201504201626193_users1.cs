namespace Nola.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationClaim_Id", "dbo.ApplicationClaims");
            DropForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", "dbo.AspNetRoles");
            AddForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationClaim_Id", "dbo.ApplicationClaims", "Id");
            AddForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationClaim_Id", "dbo.ApplicationClaims");
            AddForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationClaim_Id", "dbo.ApplicationClaims", "Id", cascadeDelete: true);
        }
    }
}
