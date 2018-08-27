namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBCreate4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "InstructorID", "dbo.Instructors");
            DropIndex("dbo.Students", new[] { "InstructorID" });
            AlterColumn("dbo.Students", "CompanyPhoneNumber", c => c.Int());
            AlterColumn("dbo.Students", "InstructorID", c => c.Int());
            CreateIndex("dbo.Students", "InstructorID");
            AddForeignKey("dbo.Students", "InstructorID", "dbo.Instructors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "InstructorID", "dbo.Instructors");
            DropIndex("dbo.Students", new[] { "InstructorID" });
            AlterColumn("dbo.Students", "InstructorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "CompanyPhoneNumber", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "InstructorID");
            AddForeignKey("dbo.Students", "InstructorID", "dbo.Instructors", "Id", cascadeDelete: true);
        }
    }
}
