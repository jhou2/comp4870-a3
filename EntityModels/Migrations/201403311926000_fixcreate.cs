namespace EntityModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                   "dbo.Choices",
                   c => new
                   {
                       ChoiceId = c.Int(nullable: false, identity: true),
                       StudentNumber = c.String(nullable: false, maxLength: 9),
                       FirstName = c.String(nullable: false, maxLength: 40),
                       LastName = c.String(nullable: false, maxLength: 40),
                       CreateDate = c.DateTime(nullable: false),
                       FirstChoice_Title = c.String(nullable: false, maxLength: 50),
                       FourthChoice_Title = c.String(nullable: false, maxLength: 50),
                       SecondChoice_Title = c.String(nullable: false, maxLength: 50),
                       Term_TermCode = c.Int(nullable: false),
                       ThirdChoice_Title = c.String(nullable: false, maxLength: 50),
                   })
                   .PrimaryKey(t => t.ChoiceId)
                   .ForeignKey("dbo.Options", t => t.FirstChoice_Title, cascadeDelete: false)
                   .ForeignKey("dbo.Options", t => t.FourthChoice_Title, cascadeDelete: false)
                   .ForeignKey("dbo.Options", t => t.SecondChoice_Title, cascadeDelete: false)
                   .ForeignKey("dbo.Terms", t => t.Term_TermCode, cascadeDelete: true)
                   .ForeignKey("dbo.Options", t => t.ThirdChoice_Title, cascadeDelete: false)
                   .Index(t => t.FirstChoice_Title)
                   .Index(t => t.FourthChoice_Title)
                   .Index(t => t.SecondChoice_Title)
                   .Index(t => t.Term_TermCode)
                   .Index(t => t.ThirdChoice_Title);

            CreateTable(
                "dbo.Options",
                c => new
                {
                    Title = c.String(nullable: false, maxLength: 50),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Title);

            CreateTable(
                "dbo.Terms",
                c => new
                {
                    TermCode = c.Int(nullable: false, identity: true),
                    Description = c.String(nullable: false, maxLength: 50),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.TermCode);
        }
        
        public override void Down()
        {
        }
    }
}
