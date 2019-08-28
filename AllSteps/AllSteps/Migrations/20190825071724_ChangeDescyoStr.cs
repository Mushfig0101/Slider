using Microsoft.EntityFrameworkCore.Migrations;

namespace AllSteps.Migrations
{
    public partial class ChangeDescyoStr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Blogs",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 600);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Description",
                table: "Blogs",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 600);
        }
    }
}
