namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        DepatmentName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "DepartmentId", c => c.Byte(nullable: false));
            AddColumn("dbo.Courses", "GPA", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Courses", "DepartmentId");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            AlterColumn("dbo.Courses", "Name", c => c.String());
            DropColumn("dbo.Courses", "GPA");
            DropColumn("dbo.Courses", "DepartmentId");
            DropTable("dbo.Departments");
        }
    }
}
