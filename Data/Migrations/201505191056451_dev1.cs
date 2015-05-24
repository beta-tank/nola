namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dev1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectTeacherUsers",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        TeacherUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.TeacherUser_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.TeacherUsers", t => t.TeacherUser_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.TeacherUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectTeacherUsers", "TeacherUser_Id", "dbo.TeacherUsers");
            DropForeignKey("dbo.SubjectTeacherUsers", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.SubjectTeacherUsers", new[] { "TeacherUser_Id" });
            DropIndex("dbo.SubjectTeacherUsers", new[] { "Subject_Id" });
            DropTable("dbo.SubjectTeacherUsers");
            DropTable("dbo.Subjects");
        }
    }
}
