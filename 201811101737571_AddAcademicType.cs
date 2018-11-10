namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAcademicType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        NoOfCourses = c.Int(nullable: false),
                        TotalCredits = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "AcademicTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Students", "AcademicTypeId");
            AddForeignKey("dbo.Students", "AcademicTypeId", "dbo.AcademicTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "AcademicTypeId", "dbo.AcademicTypes");
            DropIndex("dbo.Students", new[] { "AcademicTypeId" });
            DropColumn("dbo.Students", "AcademicTypeId");
            DropTable("dbo.AcademicTypes");
        }
    }
}
