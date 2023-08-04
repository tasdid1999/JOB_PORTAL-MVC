using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addbro2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobapplication_AspNetUsers_UserId1",
                table: "jobapplication");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "jobapplication",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "jobapplication",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "jobapplication",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_jobapplication_AspNetUsers_UserId1",
                table: "jobapplication",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobapplication_AspNetUsers_UserId1",
                table: "jobapplication");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "jobapplication",
                newName: "phoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "jobapplication",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phoneNumber",
                table: "jobapplication",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddForeignKey(
                name: "FK_jobapplication_AspNetUsers_UserId1",
                table: "jobapplication",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
