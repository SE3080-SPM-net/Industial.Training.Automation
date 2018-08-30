namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStudentEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentsEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StudentsEmail");
        }
    }
}
