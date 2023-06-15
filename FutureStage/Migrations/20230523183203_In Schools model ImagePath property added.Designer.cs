﻿// <auto-generated />
using System;
using FutureStage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FutureStage.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230523183203_In Schools model ImagePath property added")]
    partial class InSchoolsmodelImagePathpropertyadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FutureStage.Models.AdmissionConfirmation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AdmissionEnquiryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConfirmationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Remark")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AdmissionEnquiryID");

                    b.ToTable("AdmissionConfirmationTbl");
                });

            modelBuilder.Entity("FutureStage.Models.AdmissionEnquiry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EnquiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnquiryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.Property<int>("SchoolStandardID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.HasIndex("SchoolID");

                    b.HasIndex("SchoolStandardID");

                    b.ToTable("AdmissionEnquiryTbl");
                });

            modelBuilder.Entity("FutureStage.Models.AdmissionPrerequisite", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PrerequisiteDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrerequisiteTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolStandardID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SchoolStandardID");

                    b.ToTable("AdmissionPrerequisiteTbl");
                });

            modelBuilder.Entity("FutureStage.Models.AdmissionProcess", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ProcessDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolStandardID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SchoolStandardID");

                    b.ToTable("AdmissionProcessTbl");
                });

            modelBuilder.Entity("FutureStage.Models.Area", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("AreaTbl");
                });

            modelBuilder.Entity("FutureStage.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StateID");

                    b.ToTable("CityTbl");
                });

            modelBuilder.Entity("FutureStage.Models.EducationBoard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EducationBoardDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationBoardTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EducationBoardTbl");
                });

            modelBuilder.Entity("FutureStage.Models.Enquiry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EnquiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnquiryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.HasIndex("SchoolID");

                    b.ToTable("EnquiryTbl");
                });

            modelBuilder.Entity("FutureStage.Models.Facility", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FacilityDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilityTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FacilityTbl");
                });

            modelBuilder.Entity("FutureStage.Models.FeeHead", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FeeHeadDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeeHeadTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SchoolStandardID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SchoolStandardID");

                    b.ToTable("FeeHeadTbl");
                });

            modelBuilder.Entity("FutureStage.Models.GeneralEnquiryReply", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EnquiryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReplyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReplyDescription")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("EnquiryID");

                    b.ToTable("GeneralEnquiryReplyTbl");
                });

            modelBuilder.Entity("FutureStage.Models.Medium", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MediumTbl");
                });

            modelBuilder.Entity("FutureStage.Models.Parent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("ParentTbl");
                });

            modelBuilder.Entity("FutureStage.Models.Quoto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("QuotoDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuotoTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("QuotoTbl");
                });

            modelBuilder.Entity("FutureStage.Models.School", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AreaID")
                        .HasColumnType("int");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstablishmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SchoolID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AreaID");

                    b.HasIndex("SchoolID");

                    b.ToTable("SchoolTbl");
                });

            modelBuilder.Entity("FutureStage.Models.SchoolAchivement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("AchivementDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AchivementDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AchivementTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SchoolID");

                    b.ToTable("SchoolAchivementTbl");
                });

            modelBuilder.Entity("FutureStage.Models.SchoolFacility", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FacilityDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacilityID")
                        .HasColumnType("int");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FacilityID");

                    b.HasIndex("SchoolID");

                    b.ToTable("SchoolFacilityTbl");
                });

            modelBuilder.Entity("FutureStage.Models.SchoolStandard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IntakeCapacity")
                        .HasColumnType("int");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.Property<int>("StandardID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SchoolID");

                    b.HasIndex("StandardID");

                    b.ToTable("SchoolStandardTbl");
                });

            modelBuilder.Entity("FutureStage.Models.SiteAdmin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SiteAdminTbl");
                });

            modelBuilder.Entity("FutureStage.Models.Standard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("StandardDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StandardTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StandardTbl");
                });

            modelBuilder.Entity("FutureStage.Models.StandardFees", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("FeeHeadID")
                        .HasColumnType("int");

                    b.Property<int>("SchoolStandardID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeeHeadID");

                    b.HasIndex("SchoolStandardID");

                    b.ToTable("StandardFeesTbl");
                });

            modelBuilder.Entity("FutureStage.Models.StandardSeatQuoto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("QuotoID")
                        .HasColumnType("int");

                    b.Property<int>("SchoolStandardID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("QuotoID");

                    b.HasIndex("SchoolStandardID");

                    b.ToTable("StandardSeatQuotoTbl");
                });

            modelBuilder.Entity("FutureStage.Models.State", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StateTbl");
                });

            modelBuilder.Entity("FutureStage.Models.AdmissionConfirmation", b =>
                {
                    b.HasOne("FutureStage.Models.AdmissionEnquiry", "AdmissionEnquiry")
                        .WithMany("AdmissionConfirmations")
                        .HasForeignKey("AdmissionEnquiryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AdmissionEnquiry");
                });

            modelBuilder.Entity("FutureStage.Models.AdmissionEnquiry", b =>
                {
                    b.HasOne("FutureStage.Models.Parent", "Parent")
                        .WithMany("AdmissionEnquiries")
                        .HasForeignKey("ParentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FutureStage.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FutureStage.Models.SchoolStandard", "SchoolStandard")
                        .WithMany("AdmissionEnquiries")
                        .HasForeignKey("SchoolStandardID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("School");

                    b.Navigation("SchoolStandard");
                });

            modelBuilder.Entity("FutureStage.Models.AdmissionPrerequisite", b =>
                {
                    b.HasOne("FutureStage.Models.SchoolStandard", "SchoolStandard")
                        .WithMany("AdmissionPrerequisites")
                        .HasForeignKey("SchoolStandardID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SchoolStandard");
                });

            modelBuilder.Entity("FutureStage.Models.AdmissionProcess", b =>
                {
                    b.HasOne("FutureStage.Models.SchoolStandard", "SchoolStandards")
                        .WithMany("AdmissionProcesses")
                        .HasForeignKey("SchoolStandardID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SchoolStandards");
                });

            modelBuilder.Entity("FutureStage.Models.Area", b =>
                {
                    b.HasOne("FutureStage.Models.City", "City")
                        .WithMany("Areas")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("FutureStage.Models.City", b =>
                {
                    b.HasOne("FutureStage.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("FutureStage.Models.Enquiry", b =>
                {
                    b.HasOne("FutureStage.Models.Parent", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FutureStage.Models.School", "School")
                        .WithMany("Enquiries")
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("School");
                });

            modelBuilder.Entity("FutureStage.Models.FeeHead", b =>
                {
                    b.HasOne("FutureStage.Models.SchoolStandard", null)
                        .WithMany("FeeHeads")
                        .HasForeignKey("SchoolStandardID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FutureStage.Models.GeneralEnquiryReply", b =>
                {
                    b.HasOne("FutureStage.Models.Enquiry", "Enquiry")
                        .WithMany("GeneralEnquiryReplies")
                        .HasForeignKey("EnquiryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Enquiry");
                });

            modelBuilder.Entity("FutureStage.Models.Parent", b =>
                {
                    b.HasOne("FutureStage.Models.Parent", null)
                        .WithMany("Parents")
                        .HasForeignKey("ParentID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FutureStage.Models.School", b =>
                {
                    b.HasOne("FutureStage.Models.Area", "Area")
                        .WithMany("Schools")
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FutureStage.Models.School", null)
                        .WithMany("Schools")
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Area");
                });

            modelBuilder.Entity("FutureStage.Models.SchoolAchivement", b =>
                {
                    b.HasOne("FutureStage.Models.School", "School")
                        .WithMany("SchoolAchivements")
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("FutureStage.Models.SchoolFacility", b =>
                {
                    b.HasOne("FutureStage.Models.Facility", "Facility")
                        .WithMany("SchoolFacilities")
                        .HasForeignKey("FacilityID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FutureStage.Models.School", "School")
                        .WithMany("SchoolFacilities")
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Facility");

                    b.Navigation("School");
                });

            modelBuilder.Entity("FutureStage.Models.SchoolStandard", b =>
                {
                    b.HasOne("FutureStage.Models.School", "School")
                        .WithMany("SchoolStandards")
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FutureStage.Models.Standard", "Standard")
                        .WithMany("SchoolStandards")
                        .HasForeignKey("StandardID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("Standard");
                });

            modelBuilder.Entity("FutureStage.Models.StandardFees", b =>
                {
                    b.HasOne("FutureStage.Models.FeeHead", "FeeHead")
                        .WithMany("StandardFees")
                        .HasForeignKey("FeeHeadID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FutureStage.Models.SchoolStandard", "SchoolStandard")
                        .WithMany("StandardFees")
                        .HasForeignKey("SchoolStandardID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FeeHead");

                    b.Navigation("SchoolStandard");
                });

            modelBuilder.Entity("FutureStage.Models.StandardSeatQuoto", b =>
                {
                    b.HasOne("FutureStage.Models.Quoto", "Quoto")
                        .WithMany("StandardSeatQuotos")
                        .HasForeignKey("QuotoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FutureStage.Models.SchoolStandard", "SchoolStandard")
                        .WithMany("StandardSeatQuotos")
                        .HasForeignKey("SchoolStandardID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Quoto");

                    b.Navigation("SchoolStandard");
                });

            modelBuilder.Entity("FutureStage.Models.AdmissionEnquiry", b =>
                {
                    b.Navigation("AdmissionConfirmations");
                });

            modelBuilder.Entity("FutureStage.Models.Area", b =>
                {
                    b.Navigation("Schools");
                });

            modelBuilder.Entity("FutureStage.Models.City", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("FutureStage.Models.Enquiry", b =>
                {
                    b.Navigation("GeneralEnquiryReplies");
                });

            modelBuilder.Entity("FutureStage.Models.Facility", b =>
                {
                    b.Navigation("SchoolFacilities");
                });

            modelBuilder.Entity("FutureStage.Models.FeeHead", b =>
                {
                    b.Navigation("StandardFees");
                });

            modelBuilder.Entity("FutureStage.Models.Parent", b =>
                {
                    b.Navigation("AdmissionEnquiries");

                    b.Navigation("Parents");
                });

            modelBuilder.Entity("FutureStage.Models.Quoto", b =>
                {
                    b.Navigation("StandardSeatQuotos");
                });

            modelBuilder.Entity("FutureStage.Models.School", b =>
                {
                    b.Navigation("Enquiries");

                    b.Navigation("SchoolAchivements");

                    b.Navigation("SchoolFacilities");

                    b.Navigation("Schools");

                    b.Navigation("SchoolStandards");
                });

            modelBuilder.Entity("FutureStage.Models.SchoolStandard", b =>
                {
                    b.Navigation("AdmissionEnquiries");

                    b.Navigation("AdmissionPrerequisites");

                    b.Navigation("AdmissionProcesses");

                    b.Navigation("FeeHeads");

                    b.Navigation("StandardFees");

                    b.Navigation("StandardSeatQuotos");
                });

            modelBuilder.Entity("FutureStage.Models.Standard", b =>
                {
                    b.Navigation("SchoolStandards");
                });

            modelBuilder.Entity("FutureStage.Models.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
