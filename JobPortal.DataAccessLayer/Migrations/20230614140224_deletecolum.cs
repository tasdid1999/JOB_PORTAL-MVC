using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class deletecolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_AspNetUsers_UserId1",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_UserId1",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "jobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_UserId1",
                table: "jobs",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_AspNetUsers_UserId1",
                table: "jobs",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
