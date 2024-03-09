using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspCrud.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentInfo> StudentInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            
        }
    }
      

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentI__3213E83F7887DD0C");

            entity.ToTable("StudentInfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Class).HasColumnName("class");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
