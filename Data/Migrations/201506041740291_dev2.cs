namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dev2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsRight = c.Boolean(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseQuestions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.BaseQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StandartOptions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseOptions", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SingleAnswersQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseQuestions", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SingleAnswersQuestions", "Id", "dbo.BaseQuestions");
            DropForeignKey("dbo.StandartOptions", "Id", "dbo.BaseOptions");
            DropForeignKey("dbo.BaseOptions", "Question_Id", "dbo.BaseQuestions");
            DropIndex("dbo.SingleAnswersQuestions", new[] { "Id" });
            DropIndex("dbo.StandartOptions", new[] { "Id" });
            DropIndex("dbo.BaseOptions", new[] { "Question_Id" });
            DropTable("dbo.SingleAnswersQuestions");
            DropTable("dbo.StandartOptions");
            DropTable("dbo.BaseQuestions");
            DropTable("dbo.BaseOptions");
        }
    }
}
