namespace Nola.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseUsers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        ApplicationUser_Id = c.Int(nullable: false),
                        AvatarImage_Id = c.Int(),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.AvatarImage_Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.AvatarImage_Id)
                .Index(t => t.School_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsBlocked = c.Boolean(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(),
                        ApplicationRole_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.ApplicationRoles", t => t.ApplicationRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationRole_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationClaimApplicationRoles",
                c => new
                    {
                        ApplicationClaim_Id = c.Int(nullable: false),
                        ApplicationRole_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationClaim_Id, t.ApplicationRole_Id })
                .ForeignKey("dbo.ApplicationClaims", t => t.ApplicationClaim_Id)
                .ForeignKey("dbo.ApplicationRoles", t => t.ApplicationRole_Id)
                .Index(t => t.ApplicationClaim_Id)
                .Index(t => t.ApplicationRole_Id);
            
            CreateTable(
                "dbo.StudentUsers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TeachingType = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TeacherUsers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ImageLocals",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        OriginalName = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ImageRemotes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageRemotes", "Id", "dbo.Images");
            DropForeignKey("dbo.ImageLocals", "Id", "dbo.Images");
            DropForeignKey("dbo.TeacherUsers", "Id", "dbo.BaseUsers");
            DropForeignKey("dbo.StudentUsers", "Id", "dbo.BaseUsers");
            DropForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationRole_Id", "dbo.ApplicationRoles");
            DropForeignKey("dbo.ApplicationClaimApplicationRoles", "ApplicationClaim_Id", "dbo.ApplicationClaims");
            DropForeignKey("dbo.AspNetUserRoles", "ApplicationRole_Id", "dbo.ApplicationRoles");
            DropForeignKey("dbo.BaseUsers", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.BaseUsers", "AvatarImage_Id", "dbo.Images");
            DropForeignKey("dbo.BaseUsers", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.AspNetUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.AspNetUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.AspNetUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.ImageRemotes", new[] { "Id" });
            DropIndex("dbo.ImageLocals", new[] { "Id" });
            DropIndex("dbo.TeacherUsers", new[] { "Id" });
            DropIndex("dbo.StudentUsers", new[] { "Id" });
            DropIndex("dbo.ApplicationClaimApplicationRoles", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.ApplicationClaimApplicationRoles", new[] { "ApplicationClaim_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BaseUsers", new[] { "School_Id" });
            DropIndex("dbo.BaseUsers", new[] { "AvatarImage_Id" });
            DropIndex("dbo.BaseUsers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ImageRemotes");
            DropTable("dbo.ImageLocals");
            DropTable("dbo.TeacherUsers");
            DropTable("dbo.StudentUsers");
            DropTable("dbo.ApplicationClaimApplicationRoles");
            DropTable("dbo.ApplicationRoles");
            DropTable("dbo.ApplicationClaims");
            DropTable("dbo.Schools");
            DropTable("dbo.Images");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.BaseUsers");
        }
    }
}
