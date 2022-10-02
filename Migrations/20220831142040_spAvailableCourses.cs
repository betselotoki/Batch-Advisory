using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Batch_Advisory.Migrations
{
    public partial class spAvailableCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE AvailableCourses
                                AS
                                SELECT Courses.Course_Code, Courses.CourseName, Courses.CreditHour, Courses.Prerequsite_Course , Batch.BatchID AS 'Batch Taking Course'
                                FROM Courses INNER JOIN Batch 
                                ON Batch.CurrentYear=Courses.OnYear AND Batch.CurrentTerm=Courses.OnTerm
                                ORDER BY Batch.BatchID DESC ";
            migrationBuilder.Sql(procedure);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop PROCEDURE AvailableCourses";
            migrationBuilder.Sql(procedure);
        }
    }
}
