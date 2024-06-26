using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Learning_WebAPI.Models;

public partial class LearningContext : DbContext
{
    public LearningContext()
    {
    }

    public LearningContext(DbContextOptions<LearningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NewTable> NewTables { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NewTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("new_table_pkey");

            entity.ToTable("new_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NewColumn)
                .HasMaxLength(10)
                .HasColumnName("new_column");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
