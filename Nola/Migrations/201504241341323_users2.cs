namespace Nola.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "ApplicationRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BaseUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.BaseUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.ApplicationRoles", "RoleNameIndex");
            DropIndex("dbo.ApplicationClaimApplicationRoles", new[] { "ApplicationRole_Id" });
            DropPrimaryKey("dbo.AspNetUsers");
            DropPrimaryKey("dbo.AspNetUserLogins");
            DropPrimaryKey("dbo.AspNetUserRoles");
            DropPrimaryKey("dbo.ApplicationRoles");
            DropPrimaryKey("dbo.ApplicationClaimApplicationRoles");
            AddColumn("dbo.AspNetUsers", "IsBlocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUserRoles", "ApplicationRole_Id", c => c.Int());
            AlterColumn("dbo.BaseUsers", "ApplicationUser_Id", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationRoles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ApplicationRoles", "Name", c => c.String());
            AlterColumn("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            AddPrimaryKey("dbo.ApplicationRoles", "Id");
            AddPrimaryKey("dbo.ApplicationClaimApplicationRoles", new[] { "ApplicationClaim_Id", "ApplicationRole_Id" });
            CreateIndex("dbo.BaseUsers", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserRoles", "ApplicationRole_Id");
            CreateIndex("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id");
            AddForeignKey("dbo.AspNetUserRoles", "ApplicationRole_Id", "dbo.ApplicationRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BaseUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", "dbo.ApplicationRoles", "Id");
            DropColumn("dbo.BaseUsers", "IsBlocked");
            DropColumn("dbo.ApplicationRoles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.BaseUsers", "IsBlocked", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", "dbo.ApplicationRoles");
            DropForeignKey("dbo.BaseUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "ApplicationRole_Id", "dbo.ApplicationRoles");
            DropIndex("dbo.ApplicationClaimApplicationRoles", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.BaseUsers", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.ApplicationClaimApplicationRoles");
            DropPrimaryKey("dbo.ApplicationRoles");
            DropPrimaryKey("dbo.AspNetUserRoles");
            DropPrimaryKey("dbo.AspNetUserLogins");
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ApplicationRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.ApplicationRoles", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.BaseUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.AspNetUserRoles", "ApplicationRole_Id");
            DropColumn("dbo.AspNetUsers", "IsBlocked");
            AddPrimaryKey("dbo.ApplicationClaimApplicationRoles", new[] { "ApplicationClaim_Id", "ApplicationRole_Id" });
            AddPrimaryKey("dbo.ApplicationRoles", "Id");
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            CreateIndex("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id");
            CreateIndex("dbo.ApplicationRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.BaseUsers", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.BaseUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ApplicationRoles", newName: "AspNetRoles");
        }
    }
}
