using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreStudentDatabase.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAdmin> TblAdmins { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-IERTITV7;Database=StudentDB;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAdmin>(entity =>
        {
            entity.ToTable("TBL_ADMINS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("DATE_CREATED");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.ToTable("TBL_STUDENTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.StudentAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STUDENT_ADDRESS");
            entity.Property(e => e.StudentContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STUDENT_CONTACT_NUMBER");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STUDENT_NAME");
            entity.Property(e => e.StudentNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STUDENT_NUMBER");
            entity.Property(e => e.StudentYearLevel).HasColumnName("STUDENT_YEAR_LEVEL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
