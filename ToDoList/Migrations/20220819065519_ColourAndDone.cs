using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    public partial class ColourAndDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "ToDo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProjectColour",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "#e2e2e2;");

            migrationBuilder.AddColumn<string>(
                name: "CategoryColour",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "#e2e2e2;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "ProjectColour",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CategoryColour",
                table: "Category");
        }
    }
}
