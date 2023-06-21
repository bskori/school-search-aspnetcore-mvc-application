using FutureStage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School_EducationBoard>()
            .HasKey(sb => new { sb.SchoolID, sb.EducationBoardID });

            modelBuilder.Entity<School_EducationBoard>()
                .HasOne(sb => sb.School)
                .WithMany(s => s.School_EducationBoards)
                .HasForeignKey(sb => sb.SchoolID);

            modelBuilder.Entity<School_EducationBoard>()
                .HasOne(sb => sb.EducationBoard)
                .WithMany(b => b.School_EducationBoards)
                .HasForeignKey(sb => sb.EducationBoardID);

            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(n => n.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

        }

        //site admin models
        public DbSet<SiteAdmin> SiteAdmins { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Quoto> Quotos { get; set; }
        public DbSet<Medium> Mediums { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        //schools models
        public DbSet<School> Schools { get; set; }
        public DbSet<AdmissionEnquiry> AdmissionEnquiries { get; set; }
        public DbSet<AdmissionConfirmation> AdmissionConfirmations { get; set; }
        public DbSet<AdmissionPrerequisite> AdmissionPrerequisites { get; set; }
        public DbSet<AdmissionProcess> AdmissionProcesses { get; set; }
        public DbSet<EducationBoard> EducationBoards { get; set; }
        public DbSet<FeeHead> FeeHeads { get; set; }
        public DbSet<GeneralEnquiryReply> GeneralEnquiryReplies { get; set; }
        public DbSet<SchoolAchivement> SchoolAchivements { get; set; }
        public DbSet<SchoolFacility> SchoolFacilities { get; set; }
        public DbSet<SchoolStandard> SchoolStandards { get; set; }
        public DbSet<StandardFees> StandardFees { get; set; }
        public DbSet<StandardSeatQuoto> StandardSeatQuotos { get; set; }
        public DbSet<School_EducationBoard> School_EducationBoards { get; set; }


        //Parent
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
    }
}
