namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Departments : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (Id, DepartmentName) VALUES (1, 'Computational Mathematics')");
            Sql("INSERT INTO Departments (Id, DepartmentName) VALUES (2, 'Information Technology')");
            Sql("INSERT INTO Departments (Id, DepartmentName) VALUES (3, 'Interdisplinary Studies')");
        }
        
        public override void Down()
        {
        }
    }
}
