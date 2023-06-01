using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShopRunner.Entities;

public partial class ShopRunnerContext : DbContext
{
    public ShopRunnerContext()
    {
    }

    public ShopRunnerContext(DbContextOptions<ShopRunnerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.\\SQL;Initial Catalog=Shop_Runner;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3214EC07224B5AAB");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Slug, "UQ__categori__BC7B5FB6C5B17FEC").IsUnique();

            entity.Property(e => e.Slug)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3214EC077CB32F25");

            entity.ToTable("products");

            entity.HasIndex(e => e.Slug, "UQ__products__BC7B5FB638748B6D").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.ImportPrice).HasColumnType("money");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProviderId).HasColumnName("providerId");
            entity.Property(e => e.Slug)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__products__catego__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
