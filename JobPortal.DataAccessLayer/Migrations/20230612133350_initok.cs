using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobDescription",
                table: "jobs",
                newName: "Salary");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalRequirements",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationalRequirements",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeStatus",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExperienceRequirement",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobLocation",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobResponsibilities",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OthersBenefit",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalRequirements",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "EducationalRequirements",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "EmployeeStatus",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "ExperienceRequirement",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "JobLocation",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "JobResponsibilities",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "OthersBenefit",
                table: "jobs");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "jobs",
                newName: "JobDescription");
        }
    }
}
