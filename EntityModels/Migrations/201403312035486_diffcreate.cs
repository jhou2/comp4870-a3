namespace EntityModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diffcreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Choices", "FirstChoice_Title", "dbo.Options");
            DropForeignKey("dbo.Choices", "FourthChoice_Title", "dbo.Options");
            DropForeignKey("dbo.Choices", "SecondChoice_Title", "dbo.Options");
            DropForeignKey("dbo.Choices", "ThirdChoice_Title", "dbo.Options");
            DropIndex("dbo.Choices", new[] { "FirstChoice_Title" });
            DropIndex("dbo.Choices", new[] { "SecondChoice_Title" });
            DropIndex("dbo.Choices", new[] { "ThirdChoice_Title" });
            DropIndex("dbo.Choices", new[] { "FourthChoice_Title" });
            AlterColumn("dbo.Choices", "FirstChoice_Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Choices", "SecondChoice_Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Choices", "ThirdChoice_Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Choices", "FourthChoice_Title", c => c.String(maxLength: 50));
            CreateIndex("dbo.Choices", "FirstChoice_Title");
            CreateIndex("dbo.Choices", "SecondChoice_Title");
            CreateIndex("dbo.Choices", "ThirdChoice_Title");
            CreateIndex("dbo.Choices", "FourthChoice_Title");
            AddForeignKey("dbo.Choices", "FirstChoice_Title", "dbo.Options", "Title");
            AddForeignKey("dbo.Choices", "FourthChoice_Title", "dbo.Options", "Title");
            AddForeignKey("dbo.Choices", "SecondChoice_Title", "dbo.Options", "Title");
            AddForeignKey("dbo.Choices", "ThirdChoice_Title", "dbo.Options", "Title");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Choices", "ThirdChoice_Title", "dbo.Options");
            DropForeignKey("dbo.Choices", "SecondChoice_Title", "dbo.Options");
            DropForeignKey("dbo.Choices", "FourthChoice_Title", "dbo.Options");
            DropForeignKey("dbo.Choices", "FirstChoice_Title", "dbo.Options");
            DropIndex("dbo.Choices", new[] { "FourthChoice_Title" });
            DropIndex("dbo.Choices", new[] { "ThirdChoice_Title" });
            DropIndex("dbo.Choices", new[] { "SecondChoice_Title" });
            DropIndex("dbo.Choices", new[] { "FirstChoice_Title" });
            AlterColumn("dbo.Choices", "FourthChoice_Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Choices", "ThirdChoice_Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Choices", "SecondChoice_Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Choices", "FirstChoice_Title", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Choices", "FourthChoice_Title");
            CreateIndex("dbo.Choices", "ThirdChoice_Title");
            CreateIndex("dbo.Choices", "SecondChoice_Title");
            CreateIndex("dbo.Choices", "FirstChoice_Title");
            AddForeignKey("dbo.Choices", "ThirdChoice_Title", "dbo.Options", "Title", cascadeDelete: true);
            AddForeignKey("dbo.Choices", "SecondChoice_Title", "dbo.Options", "Title", cascadeDelete: true);
            AddForeignKey("dbo.Choices", "FourthChoice_Title", "dbo.Options", "Title", cascadeDelete: true);
            AddForeignKey("dbo.Choices", "FirstChoice_Title", "dbo.Options", "Title", cascadeDelete: true);
        }
    }
}
