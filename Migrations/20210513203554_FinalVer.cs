using Microsoft.EntityFrameworkCore.Migrations;

namespace Active_Directory.Migrations
{
    public partial class FinalVer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "Profesores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantID",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
