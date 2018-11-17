namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDegreeNameToAcademicType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AcademicTypes", "DegreeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AcademicTypes", "DegreeName");
            DropTable("dbo.Courses");
        }
    }
}
