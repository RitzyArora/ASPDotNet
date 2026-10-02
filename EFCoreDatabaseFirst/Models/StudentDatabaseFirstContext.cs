using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirst.Models;

public partial class StudentDatabaseFirstContext : DbContext
{
    public StudentDatabaseFirstContext()
    {
    }

    public StudentDatabaseFirstContext(DbContextOptions<StudentDatabaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=RITIKAARORA;Database=StudentDatabaseFirst;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("PK__STUDENTS__495196F0D15B27E8");

            entity.ToTable("STUDENTS");

            entity.Property(e => e.Studentid).HasColumnName("STUDENTID");
            entity.Property(e => e.Studentage).HasColumnName("STUDENTAGE");
            entity.Property(e => e.Studentmarks)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("STUDENTMARKS");
            entity.Property(e => e.Studentname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STUDENTNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
