using Microsoft.EntityFrameworkCore.Migrations;

namespace FutureStage.Migrations
{
    public partial class InFeeHeadFeeHeadTitlerenamedtoFeeHeadNameFeeHeadDescremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeeHeadDescription",
                table: "FeeHeadTbl");

            migrationBuilder.RenameColumn(
                name: "FeeHeadTitle",
                table: "FeeHeadTbl",
                newName: "FeeHeadName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeeHeadName",
                table: "FeeHeadTbl",
                newName: "FeeHeadTitle");

            migrationBuilder.AddColumn<string>(
                name: "FeeHeadDescription",
                table: "FeeHeadTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
