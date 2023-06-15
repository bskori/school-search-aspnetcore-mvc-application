using Microsoft.EntityFrameworkCore.Migrations;

namespace FutureStage.Migrations
{
    public partial class ParentIDremovedfromParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentTbl_ParentTbl_ParentID",
                table: "ParentTbl");

            migrationBuilder.DropIndex(
                name: "IX_ParentTbl_ParentID",
                table: "ParentTbl");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "ParentTbl");

            migrationBuilder.CreateTable(
                name: "School_EducationBoards",
                columns: table => new
                {
                    SchoolID = table.Column<int>(type: "int", nullable: false),
                    EducationBoardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_EducationBoards", x => new { x.SchoolID, x.EducationBoardID });
                    table.ForeignKey(
                        name: "FK_School_EducationBoards_EducationBoardTbl_EducationBoardID",
                        column: x => x.EducationBoardID,
                        principalTable: "EducationBoardTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_EducationBoards_SchoolTbl_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "SchoolTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_School_EducationBoards_EducationBoardID",
                table: "School_EducationBoards",
                column: "EducationBoardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School_EducationBoards");

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "ParentTbl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParentTbl_ParentID",
                table: "ParentTbl",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentTbl_ParentTbl_ParentID",
                table: "ParentTbl",
                column: "ParentID",
                principalTable: "ParentTbl",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
