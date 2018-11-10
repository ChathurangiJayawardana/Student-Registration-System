namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAcademicTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AcademicTypes(Id,NoOfCourses,TotalCredits,Year)VALUES(1,12,33,1)");
            Sql("INSERT INTO AcademicTypes(Id,NoOfCourses,TotalCredits,Year)VALUES(2,15,40,2)");
            Sql("INSERT INTO AcademicTypes(Id,NoOfCourses,TotalCredits,Year)VALUES(3,16,42,3)");
            Sql("INSERT INTO AcademicTypes(Id,NoOfCourses,TotalCredits,Year)VALUES(4,14,38,4)");
        }
        
        public override void Down()
        {
        }
    }
}
