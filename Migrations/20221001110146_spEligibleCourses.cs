using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Batch_Advisory.Migrations
{
    public partial class spEligibleCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE EligibleCourses @id varchar(6) 
                                    AS
                                    SELECT Courses.Course_Code, Courses.CourseName, Courses.CreditHour, Courses.Prerequsite_Course ,Batch.BatchID AS 'Batch Taking Course'
                                    FROM Courses INNER JOIN Batch
                                    ON Batch.CurrentYear=Courses.OnYear AND Batch.CurrentTerm=Courses.OnTerm 
                                    INNER JOIN CoursesTaken 
                                    ON Courses.Course_Code=CoursesTaken.Course_Code
                                    WHERE CoursesTaken.SRC=@id AND CoursesTaken.Grade='F'
                                    ORDER BY Courses.CourseName DESC ";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop PROCEDURE EligibleCourses";
            migrationBuilder.Sql(procedure);
        }
    }
}
