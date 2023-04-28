using Microsoft.EntityFrameworkCore.Migrations;

namespace FutureStage.Migrations
{
    public partial class AreatablenamerenamedfromAreatoAreaTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_CityTbl_CityID",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolTbl_Area_AreaID",
                table: "SchoolTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Area",
                table: "Area");

            migrationBuilder.RenameTable(
                name: "Area",
                newName: "AreaTbl");

            migrationBuilder.RenameIndex(
                name: "IX_Area_CityID",
                table: "AreaTbl",
                newName: "IX_AreaTbl_CityID");

            migrationBuilder.AlterColumn<string>(
                name: "StateName",
                table: "StateTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "SiteAdminTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "SiteAdminTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "CountyTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "CityTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AreaName",
                table: "AreaTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaTbl",
                table: "AreaTbl",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaTbl_CityTbl_CityID",
                table: "AreaTbl",
                column: "CityID",
                principalTable: "CityTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolTbl_AreaTbl_AreaID",
                table: "SchoolTbl",
                column: "AreaID",
                principalTable: "AreaTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaTbl_CityTbl_CityID",
                table: "AreaTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolTbl_AreaTbl_AreaID",
                table: "SchoolTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaTbl",
                table: "AreaTbl");

            migrationBuilder.RenameTable(
                name: "AreaTbl",
                newName: "Area");

            migrationBuilder.RenameIndex(
                name: "IX_AreaTbl_CityID",
                table: "Area",
                newName: "IX_Area_CityID");

            migrationBuilder.AlterColumn<string>(
                name: "StateName",
                table: "StateTbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "SiteAdminTbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "SiteAdminTbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "CountyTbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "CityTbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AreaName",
                table: "Area",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Area",
                table: "Area",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_CityTbl_CityID",
                table: "Area",
                column: "CityID",
                principalTable: "CityTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolTbl_Area_AreaID",
                table: "SchoolTbl",
                column: "AreaID",
                principalTable: "Area",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
