namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "VivaSheduledDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "VivaSheduledDate", c => c.DateTime(nullable: false));
        }
    }
}
