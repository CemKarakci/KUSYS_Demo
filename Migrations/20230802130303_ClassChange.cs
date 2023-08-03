using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUSYS_Demo.Migrations
{
    public partial class ClassChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Course",
                newName: "CourseCode");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Enrollment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Enrollment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Enrollment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "CourseCode",
                table: "Course",
                newName: "CourseId");
        }
    }
}
