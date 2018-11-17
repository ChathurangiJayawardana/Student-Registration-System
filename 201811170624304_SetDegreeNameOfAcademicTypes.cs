namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDegreeNameOfAcademicTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AcademicTypes SET DegreeName='B.Sc(Hons)Information Technology'WHERE Id=1");
            Sql("UPDATE AcademicTypes SET DegreeName='B.Sc(Hons)Information Technology Management'WHERE Id=2");
            Sql("UPDATE AcademicTypes SET DegreeName='B.Sc(Hons)Electrical Engineering'WHERE Id=3");

        }
        
        public override void Down()
        {
        }
    }
}
