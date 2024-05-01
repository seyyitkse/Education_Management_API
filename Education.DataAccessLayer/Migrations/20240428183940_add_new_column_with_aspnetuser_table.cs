using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.DataAccessLayer.Migrations
{
    public partial class add_new_column_with_aspnetuser_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CafeteriaCardID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CafeteriaCardID",
                table: "AspNetUsers");
        }
    }
}
