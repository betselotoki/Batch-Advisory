﻿// <auto-generated />
using System;
using Batch_Advisory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Batch_Advisory.Migrations
{
    [DbContext(typeof(Batch_AdvisoryContext))]
    partial class Batch_AdvisoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Batch_Advisory.Models.Advisor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("AssignedBatch")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedBatch");

                    b.ToTable("Advisor", (string)null);
                });

            modelBuilder.Entity("Batch_Advisory.Models.AvailableCourse", b =>
                {
                    b.Property<string>("BatchTakingCourse")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)")
                        .HasColumnName("Batch Taking Course");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("Course_Code");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("CreditHour")
                        .HasColumnType("int");

                    b.Property<string>("PrerequsiteCourse")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("Prerequsite_Course");

                    b.ToTable("AvailableCourses");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Batch", b =>
                {
                    b.Property<string>("BatchId")
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)")
                        .HasColumnName("BatchID");

                    b.Property<int>("BatchSize")
                        .HasColumnType("int");

                    b.Property<string>("CurrentTerm")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)");

                    b.Property<int>("CurrentYear")
                        .HasColumnType("int");

                    b.Property<int?>("TotalCourses")
                        .HasColumnType("int");

                    b.HasKey("BatchId");

                    b.HasIndex("CurrentTerm");

                    b.ToTable("Batch", (string)null);
                });

            modelBuilder.Entity("Batch_Advisory.Models.ClassRoom", b =>
                {
                    b.Property<string>("Room")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.Property<int>("Available")
                        .HasColumnType("int");

                    b.Property<int>("ClassSize")
                        .HasColumnType("int")
                        .HasColumnName("Class_Size");

                    b.HasKey("Room")
                        .HasName("PK__ClassRoo__DA155984A132F001");

                    b.ToTable("ClassRoom", (string)null);
                });

            modelBuilder.Entity("Batch_Advisory.Models.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("Course_Code");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("CreditHour")
                        .HasColumnType("int");

                    b.Property<string>("OnTerm")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)");

                    b.Property<int>("OnYear")
                        .HasColumnType("int");

                    b.Property<string>("PrerequsiteCourse")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("Prerequsite_Course");

                    b.HasKey("CourseCode")
                        .HasName("PK__Courses__1AE5B24C0E0905B0");

                    b.HasIndex("OnTerm");

                    b.HasIndex("PrerequsiteCourse");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Student", b =>
                {
                    b.Property<string>("Src")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("SRC");

                    b.Property<string>("Batch")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)");

                    b.Property<int?>("CoursesCompleted")
                        .HasColumnType("int");

                    b.Property<int?>("CoursesRegistered")
                        .HasColumnType("int");

                    b.Property<double?>("Gpa")
                        .HasColumnType("float")
                        .HasColumnName("GPA");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Src")
                        .HasName("PK__Students__CA1E8621CDC45F66");

                    b.HasIndex("Batch");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Term", b =>
                {
                    b.Property<string>("TermId")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)")
                        .HasColumnName("TermID");

                    b.Property<string>("TermName")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.HasKey("TermId");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Advisor", b =>
                {
                    b.HasOne("Batch_Advisory.Models.Batch", "AssignedBatchNavigation")
                        .WithMany("Advisors")
                        .HasForeignKey("AssignedBatch")
                        .IsRequired()
                        .HasConstraintName("AdvisorBatch_Fk");

                    b.Navigation("AssignedBatchNavigation");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Batch", b =>
                {
                    b.HasOne("Batch_Advisory.Models.Term", "CurrentTermNavigation")
                        .WithMany("Batches")
                        .HasForeignKey("CurrentTerm")
                        .IsRequired()
                        .HasConstraintName("BatchTerm");

                    b.Navigation("CurrentTermNavigation");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Course", b =>
                {
                    b.HasOne("Batch_Advisory.Models.Term", "OnTermNavigation")
                        .WithMany("Courses")
                        .HasForeignKey("OnTerm")
                        .IsRequired()
                        .HasConstraintName("CourseTerm");

                    b.HasOne("Batch_Advisory.Models.Course", "PrerequsiteCourseNavigation")
                        .WithMany("InversePrerequsiteCourseNavigation")
                        .HasForeignKey("PrerequsiteCourse")
                        .HasConstraintName("PreCourse");

                    b.Navigation("OnTermNavigation");

                    b.Navigation("PrerequsiteCourseNavigation");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Student", b =>
                {
                    b.HasOne("Batch_Advisory.Models.Batch", "BatchNavigation")
                        .WithMany("Students")
                        .HasForeignKey("Batch")
                        .IsRequired()
                        .HasConstraintName("StudentBatch_Fk");

                    b.Navigation("BatchNavigation");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Batch", b =>
                {
                    b.Navigation("Advisors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Course", b =>
                {
                    b.Navigation("InversePrerequsiteCourseNavigation");
                });

            modelBuilder.Entity("Batch_Advisory.Models.Term", b =>
                {
                    b.Navigation("Batches");

                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
