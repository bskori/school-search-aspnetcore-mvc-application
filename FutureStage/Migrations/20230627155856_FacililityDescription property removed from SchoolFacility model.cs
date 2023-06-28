using Microsoft.EntityFrameworkCore.Migrations;

namespace FutureStage.Migrations
{
    public partial class FacililityDescriptionpropertyremovedfromSchoolFacilitymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacilityDescription",
                table: "SchoolFacilityTbl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacilityDescription",
                table: "SchoolFacilityTbl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
