using Microsoft.EntityFrameworkCore.Migrations;

namespace FutureStage.Migrations
{
    public partial class onetomanyrelationshipaddedbetweenSchoolStandardandFeeHead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SchoolStandardID",
                table: "FeeHeadTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SchoolStandardID",
                table: "FeeHeadTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
