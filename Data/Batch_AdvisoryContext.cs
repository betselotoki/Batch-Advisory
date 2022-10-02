using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Batch_Advisory.Models;

namespace Batch_Advisory.Data
{
    public partial class Batch_AdvisoryContext : DbContext
    {
        public Batch_AdvisoryContext()
        {
        }

        public Batch_AdvisoryContext(DbContextOptions<Batch_AdvisoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advisor> Advisors { get; set; } = null!;
        public virtual DbSet<Batch> Batches { get; set; } = null!;
        public virtual DbSet<ClassRoom> ClassRooms { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CoursesRegistered> CoursesRegistereds { get; set; } = null!;
        public virtual DbSet<CoursesTaken> CoursesTakens { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Term> Terms { get; set; } = null!;
        public virtual DbSet<AvailableCourse> AvailableCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=TOKISDELLG5;Initial Catalog=Batch_Advisory;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableCourse>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Course_Code");

                entity.Property(e => e.CourseName).IsUnicode(false);

                entity.Property(e => e.CreditHour);

                entity.Property(e => e.PrerequsiteCourse)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Prerequsite_Course");

                entity.Property(e => e.BatchTakingCourse)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("Batch Taking Course");
            });


            modelBuilder.Entity<Advisor>(entity =>
            {
                entity.ToTable("Advisor");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AssignedBatch)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.HasOne(d => d.AssignedBatchNavigation)
                    .WithMany(p => p.Advisors)
                    .HasForeignKey(d => d.AssignedBatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AdvisorBatch_Fk");
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.ToTable("Batch");

                entity.Property(e => e.BatchId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("BatchID");

                entity.Property(e => e.CurrentTerm)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.CurrentTermNavigation)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.CurrentTerm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BatchTerm");
            });

            modelBuilder.Entity<ClassRoom>(entity =>
            {
                entity.HasKey(e => e.Room)
                    .HasName("PK__ClassRoo__DA155984A132F001");

                entity.ToTable("ClassRoom");

                entity.Property(e => e.Room)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ClassSize).HasColumnName("Class_Size");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseCode)
                    .HasName("PK__Courses__1AE5B24C0E0905B0");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Course_Code");

                entity.Property(e => e.CourseName).IsUnicode(false);

                entity.Property(e => e.OnTerm)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PrerequsiteCourse)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Prerequsite_Course");

                entity.HasOne(d => d.OnTermNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.OnTerm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CourseTerm");

                entity.HasOne(d => d.PrerequsiteCourseNavigation)
                    .WithMany(p => p.InversePrerequsiteCourseNavigation)
                    .HasForeignKey(d => d.PrerequsiteCourse)
                    .HasConstraintName("PreCourse");
            });

            modelBuilder.Entity<CoursesRegistered>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CoursesRegistered");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Course_Code");

                entity.Property(e => e.Src)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SRC");

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CourseCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CoursesRegisteredCode_Fk");

                entity.HasOne(d => d.SrcNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Src)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CoursesRegisteredSRC_Fk");
            });

            modelBuilder.Entity<CoursesTaken>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CoursesTaken");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Course_Code");

                entity.Property(e => e.Grade)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Src)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SRC");

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CourseCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CoursesTakenCode_Fk");

                entity.HasOne(d => d.SrcNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Src)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CoursesTakenSRC_Fk");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Src)
                    .HasName("PK__Students__CA1E8621CDC45F66");

                entity.Property(e => e.Src)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SRC");

                entity.Property(e => e.Batch)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Gpa).HasColumnName("GPA");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.HasOne(d => d.BatchNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Batch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StudentBatch_Fk");
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.Property(e => e.TermId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TermID");

                entity.Property(e => e.TermName)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
