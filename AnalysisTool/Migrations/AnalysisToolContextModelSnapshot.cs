﻿// <auto-generated />
using System;
using AnalysisTool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnalysisTool.Migrations
{
    [DbContext(typeof(AnalysisToolContext))]
    partial class AnalysisToolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnalysisTool.Models.Assessment", b =>
                {
                    b.Property<int>("AssessmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssessmentName")
                        .IsRequired();

                    b.Property<string>("AssessmentVersion")
                        .IsRequired();

                    b.HasKey("AssessmentId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("AnalysisTool.Models.AssessmentSession", b =>
                {
                    b.Property<int>("AssessmentSessionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDateTime");

                    b.Property<int>("MoodRating");

                    b.Property<DateTime?>("StartDateTime");

                    b.Property<int>("UserId");

                    b.HasKey("AssessmentSessionId");

                    b.HasIndex("UserId");

                    b.ToTable("AssessmentSessions");
                });

            modelBuilder.Entity("AnalysisTool.Models.AssessmentSessionStepResult", b =>
                {
                    b.Property<int>("AssessmentSessionStepResultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssessmentOrder");

                    b.Property<int>("AssessmentSessionId");

                    b.Property<int>("AssessmentStepId");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<int>("Points");

                    b.Property<DateTime>("StartDateTime");

                    b.HasKey("AssessmentSessionStepResultId");

                    b.HasIndex("AssessmentSessionId");

                    b.HasIndex("AssessmentStepId");

                    b.ToTable("AssessmentSessionStepResults");
                });

            modelBuilder.Entity("AnalysisTool.Models.AssessmentStep", b =>
                {
                    b.Property<int>("AssessmentStepId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssessmentId");

                    b.Property<string>("Instructions")
                        .IsRequired();

                    b.Property<string>("MetaData")
                        .IsRequired();

                    b.Property<int>("PossiblePoints");

                    b.Property<string>("StepName")
                        .IsRequired();

                    b.HasKey("AssessmentStepId");

                    b.HasIndex("AssessmentId");

                    b.ToTable("AssessmentSteps");
                });

            modelBuilder.Entity("AnalysisTool.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirthYear");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnalysisTool.Models.UserAssessment", b =>
                {
                    b.Property<int>("UserAssessmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssessmentId");

                    b.Property<string>("Frequency")
                        .IsRequired();

                    b.Property<string>("PrescribingProvider")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.Property<DateTime>("WindowEndDateTime");

                    b.Property<DateTime>("WindowStartDateTime");

                    b.HasKey("UserAssessmentId");

                    b.HasIndex("AssessmentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAssessments");
                });

            modelBuilder.Entity("AnalysisTool.Models.AssessmentSession", b =>
                {
                    b.HasOne("AnalysisTool.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AnalysisTool.Models.AssessmentSessionStepResult", b =>
                {
                    b.HasOne("AnalysisTool.Models.AssessmentSession", "AssessmentSession")
                        .WithMany()
                        .HasForeignKey("AssessmentSessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AnalysisTool.Models.AssessmentStep", "AssessmentStep")
                        .WithMany()
                        .HasForeignKey("AssessmentStepId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AnalysisTool.Models.AssessmentStep", b =>
                {
                    b.HasOne("AnalysisTool.Models.Assessment", "Assessment")
                        .WithMany("AssessmentSteps")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AnalysisTool.Models.UserAssessment", b =>
                {
                    b.HasOne("AnalysisTool.Models.Assessment", "Assessment")
                        .WithMany()
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AnalysisTool.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
