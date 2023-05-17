using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FutureStage.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountyTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyTbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EducationBoardTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationBoardTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationBoardDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationBoardTbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FacilityTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MediumTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediumTbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParentTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ParentTbl_ParentTbl_ParentID",
                        column: x => x.ParentID,
                        principalTable: "ParentTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotoTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotoTbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SiteAdminTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteAdminTbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StandardTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardTbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StateTbl_CountyTbl_CountryID",
                        column: x => x.CountryID,
                        principalTable: "CountyTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CityTbl_StateTbl_StateID",
                        column: x => x.StateID,
                        principalTable: "StateTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreaTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AreaTbl_CityTbl_CityID",
                        column: x => x.CityID,
                        principalTable: "CityTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaID = table.Column<int>(type: "int", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SchoolTbl_AreaTbl_AreaID",
                        column: x => x.AreaID,
                        principalTable: "AreaTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolTbl_SchoolTbl_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "SchoolTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnquiryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnquiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnquiryTbl_ParentTbl_ParentID",
                        column: x => x.ParentID,
                        principalTable: "ParentTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnquiryTbl_SchoolTbl_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "SchoolTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolAchivementTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchivementTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AchivementDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AchivementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAchivementTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SchoolAchivementTbl_SchoolTbl_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "SchoolTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolFacilityTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolID = table.Column<int>(type: "int", nullable: false),
                    FacilityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolFacilityTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SchoolFacilityTbl_FacilityTbl_FacilityID",
                        column: x => x.FacilityID,
                        principalTable: "FacilityTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolFacilityTbl_SchoolTbl_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "SchoolTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolStandardTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntakeCapacity = table.Column<int>(type: "int", nullable: false),
                    StandardID = table.Column<int>(type: "int", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolStandardTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SchoolStandardTbl_SchoolTbl_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "SchoolTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolStandardTbl_StandardTbl_StandardID",
                        column: x => x.StandardID,
                        principalTable: "StandardTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralEnquiryReplyTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyDescription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnquiryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralEnquiryReplyTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GeneralEnquiryReplyTbl_EnquiryTbl_EnquiryID",
                        column: x => x.EnquiryID,
                        principalTable: "EnquiryTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionEnquiryTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnquiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnquiryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false),
                    SchoolStandardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionEnquiryTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdmissionEnquiryTbl_ParentTbl_ParentID",
                        column: x => x.ParentID,
                        principalTable: "ParentTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionEnquiryTbl_SchoolStandardTbl_SchoolStandardID",
                        column: x => x.SchoolStandardID,
                        principalTable: "SchoolStandardTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionEnquiryTbl_SchoolTbl_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "SchoolTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionPrerequisiteTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrerequisiteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrerequisiteDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolStandardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionPrerequisiteTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdmissionPrerequisiteTbl_SchoolStandardTbl_SchoolStandardID",
                        column: x => x.SchoolStandardID,
                        principalTable: "SchoolStandardTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionProcessTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolStandardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionProcessTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdmissionProcessTbl_SchoolStandardTbl_SchoolStandardID",
                        column: x => x.SchoolStandardID,
                        principalTable: "SchoolStandardTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeeHeadTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeHeadTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeHeadDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolStandardID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeHeadTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FeeHeadTbl_SchoolStandardTbl_SchoolStandardID",
                        column: x => x.SchoolStandardID,
                        principalTable: "SchoolStandardTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StandardSeatQuotoTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    SchoolStandardID = table.Column<int>(type: "int", nullable: false),
                    QuotoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardSeatQuotoTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StandardSeatQuotoTbl_QuotoTbl_QuotoID",
                        column: x => x.QuotoID,
                        principalTable: "QuotoTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StandardSeatQuotoTbl_SchoolStandardTbl_SchoolStandardID",
                        column: x => x.SchoolStandardID,
                        principalTable: "SchoolStandardTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionConfirmationTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<bool>(type: "bit", nullable: false),
                    AdmissionEnquiryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionConfirmationTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdmissionConfirmationTbl_AdmissionEnquiryTbl_AdmissionEnquiryID",
                        column: x => x.AdmissionEnquiryID,
                        principalTable: "AdmissionEnquiryTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StandardFeesTbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    SchoolStandardID = table.Column<int>(type: "int", nullable: false),
                    FeeHeadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardFeesTbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StandardFeesTbl_FeeHeadTbl_FeeHeadID",
                        column: x => x.FeeHeadID,
                        principalTable: "FeeHeadTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StandardFeesTbl_SchoolStandardTbl_SchoolStandardID",
                        column: x => x.SchoolStandardID,
                        principalTable: "SchoolStandardTbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionConfirmationTbl_AdmissionEnquiryID",
                table: "AdmissionConfirmationTbl",
                column: "AdmissionEnquiryID");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionEnquiryTbl_ParentID",
                table: "AdmissionEnquiryTbl",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionEnquiryTbl_SchoolID",
                table: "AdmissionEnquiryTbl",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionEnquiryTbl_SchoolStandardID",
                table: "AdmissionEnquiryTbl",
                column: "SchoolStandardID");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionPrerequisiteTbl_SchoolStandardID",
                table: "AdmissionPrerequisiteTbl",
                column: "SchoolStandardID");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionProcessTbl_SchoolStandardID",
                table: "AdmissionProcessTbl",
                column: "SchoolStandardID");

            migrationBuilder.CreateIndex(
                name: "IX_AreaTbl_CityID",
                table: "AreaTbl",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_CityTbl_StateID",
                table: "CityTbl",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryTbl_ParentID",
                table: "EnquiryTbl",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryTbl_SchoolID",
                table: "EnquiryTbl",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_FeeHeadTbl_SchoolStandardID",
                table: "FeeHeadTbl",
                column: "SchoolStandardID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralEnquiryReplyTbl_EnquiryID",
                table: "GeneralEnquiryReplyTbl",
                column: "EnquiryID");

            migrationBuilder.CreateIndex(
                name: "IX_ParentTbl_ParentID",
                table: "ParentTbl",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAchivementTbl_SchoolID",
                table: "SchoolAchivementTbl",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFacilityTbl_FacilityID",
                table: "SchoolFacilityTbl",
                column: "FacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFacilityTbl_SchoolID",
                table: "SchoolFacilityTbl",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStandardTbl_SchoolID",
                table: "SchoolStandardTbl",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStandardTbl_StandardID",
                table: "SchoolStandardTbl",
                column: "StandardID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTbl_AreaID",
                table: "SchoolTbl",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTbl_SchoolID",
                table: "SchoolTbl",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_StandardFeesTbl_FeeHeadID",
                table: "StandardFeesTbl",
                column: "FeeHeadID");

            migrationBuilder.CreateIndex(
                name: "IX_StandardFeesTbl_SchoolStandardID",
                table: "StandardFeesTbl",
                column: "SchoolStandardID");

            migrationBuilder.CreateIndex(
                name: "IX_StandardSeatQuotoTbl_QuotoID",
                table: "StandardSeatQuotoTbl",
                column: "QuotoID");

            migrationBuilder.CreateIndex(
                name: "IX_StandardSeatQuotoTbl_SchoolStandardID",
                table: "StandardSeatQuotoTbl",
                column: "SchoolStandardID");

            migrationBuilder.CreateIndex(
                name: "IX_StateTbl_CountryID",
                table: "StateTbl",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionConfirmationTbl");

            migrationBuilder.DropTable(
                name: "AdmissionPrerequisiteTbl");

            migrationBuilder.DropTable(
                name: "AdmissionProcessTbl");

            migrationBuilder.DropTable(
                name: "EducationBoardTbl");

            migrationBuilder.DropTable(
                name: "GeneralEnquiryReplyTbl");

            migrationBuilder.DropTable(
                name: "MediumTbl");

            migrationBuilder.DropTable(
                name: "SchoolAchivementTbl");

            migrationBuilder.DropTable(
                name: "SchoolFacilityTbl");

            migrationBuilder.DropTable(
                name: "SiteAdminTbl");

            migrationBuilder.DropTable(
                name: "StandardFeesTbl");

            migrationBuilder.DropTable(
                name: "StandardSeatQuotoTbl");

            migrationBuilder.DropTable(
                name: "AdmissionEnquiryTbl");

            migrationBuilder.DropTable(
                name: "EnquiryTbl");

            migrationBuilder.DropTable(
                name: "FacilityTbl");

            migrationBuilder.DropTable(
                name: "FeeHeadTbl");

            migrationBuilder.DropTable(
                name: "QuotoTbl");

            migrationBuilder.DropTable(
                name: "ParentTbl");

            migrationBuilder.DropTable(
                name: "SchoolStandardTbl");

            migrationBuilder.DropTable(
                name: "SchoolTbl");

            migrationBuilder.DropTable(
                name: "StandardTbl");

            migrationBuilder.DropTable(
                name: "AreaTbl");

            migrationBuilder.DropTable(
                name: "CityTbl");

            migrationBuilder.DropTable(
                name: "StateTbl");

            migrationBuilder.DropTable(
                name: "CountyTbl");
        }
    }
}
