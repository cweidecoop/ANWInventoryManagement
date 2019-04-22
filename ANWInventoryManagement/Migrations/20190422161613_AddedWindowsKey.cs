using Microsoft.EntityFrameworkCore.Migrations;

namespace ANWInventoryManagement.Migrations
{
    public partial class AddedWindowsKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WindowsKey",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WindowsKey",
                table: "Items");
        }
    }
}
