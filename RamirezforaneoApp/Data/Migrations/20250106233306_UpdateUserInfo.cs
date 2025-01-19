using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RamirezforaneoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CedulaUser",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudyProgram",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SessionNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UserCreationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CedulaUser",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudyProgram",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SessionNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserCreationDate",
                table: "AspNetUsers");
        }
    }
}
