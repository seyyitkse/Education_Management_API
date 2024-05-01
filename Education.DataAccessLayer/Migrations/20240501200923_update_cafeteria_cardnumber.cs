using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.DataAccessLayer.Migrations
{
    public partial class update_cafeteria_cardnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CardNumber",
                table: "CafeteriaCards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "CardNumber",
                table: "CafeteriaCards",
                type: "tinyint unsigned",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
