using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewspaperServer.Models;

public partial class NewContext : DbContext
{
    public NewContext()
    {
    }

    public NewContext(DbContextOptions<NewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address1> Address1s { get; set; }
    public virtual DbSet<NewsForPack> NewsForPacks { get; set; }
    public virtual DbSet<Newspaper> Newspapers { get; set; }
    public virtual DbSet<Packages1> Packages1s { get; set; }
    public virtual DbSet<Section> Sections { get; set; }
    public virtual DbSet<Subscrition> Subscritions { get; set; }
    public virtual DbSet<TypeWorker> TypeWorkers { get; set; }
    public virtual DbSet<Worker> Workers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L9S4R74;Database=NEW;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address1>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__address1__CAA247C8BC71EC90");
            entity.ToTable("address1");
            entity.Property(e => e.AddressId).ValueGeneratedNever().HasColumnName("address_id");
            entity.Property(e => e.City).HasMaxLength(20).IsUnicode(false).HasColumnName("city");
            entity.Property(e => e.HouseNumber).HasColumnName("house_number");
            entity.Property(e => e.Street).HasMaxLength(20).IsUnicode(false).HasColumnName("street");
            entity.Property(e => e.ZipCode).HasColumnName("zip_code");
        });

     
        modelBuilder.Entity<NewsForPack>(entity =>
        {
            entity.HasKey(e => e.NewsForPackId).HasName("PK__news_for__B8CB6B6E5B5582EF");
            entity.ToTable("news_for_pack");
            entity.Property(e => e.NewsForPackId).ValueGeneratedNever().HasColumnName("news_for_pack_id");
            entity.Property(e => e.NewsId).HasColumnName("news_id");
            entity.Property(e => e.PackageId).HasColumnName("package_id");

            entity.HasOne(d => d.News).WithMany(p => p.NewsForPacks)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_news_id");

            entity.HasOne(d => d.Package).WithMany(p => p.NewsForPacks)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_package_id");
        });

        modelBuilder.Entity<Newspaper>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__newspape__4C27CCD82E9E50E6");
            entity.ToTable("newspaper");
            entity.Property(e => e.NewsId).ValueGeneratedNever().HasColumnName("news_id");
            entity.Property(e => e.TypeNews).HasMaxLength(50).IsUnicode(false).HasColumnName("type_news");
        });

        modelBuilder.Entity<Packages1>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__packages__63846AE8F6247BC8");
            entity.ToTable("packages1");
            entity.Property(e => e.PackageId).ValueGeneratedNever().HasColumnName("package_id");
            entity.Property(e => e.NumNewspaper).HasColumnName("num_newspaper");
            entity.Property(e => e.NumSubscrition).HasMaxLength(200).IsUnicode(false).HasColumnName("num_subscrition");
            entity.Property(e => e.PackageType).HasMaxLength(50).IsUnicode(false).HasColumnName("package_type");
            entity.Property(e => e.Payment).HasColumnName("payment");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionsId).HasName("PK__sections__CE9F3A87E530728B");
            entity.ToTable("sections");
            entity.Property(e => e.SectionsId).ValueGeneratedNever().HasColumnName("sections_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.NameSec).HasMaxLength(10).IsUnicode(false).HasColumnName("name_sec");
            entity.Property(e => e.NewsId).HasColumnName("news_id");
            entity.Property(e => e.WorkerId).HasMaxLength(10).IsUnicode(false).HasColumnName("worker_id");

        
            entity.HasOne(d => d.News).WithMany(p => p.Sections)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_news_id2");

            entity.HasOne(d => d.Worker).WithMany(p => p.Sections)
                .HasForeignKey(d => d.WorkerId)
                .HasConstraintName("FK_worker_id5");
        });

        modelBuilder.Entity<Subscrition>(entity =>
        {
            entity.HasKey(e => e.SubId).HasName("PK__subscrit__694106B0F43D03FE");
            entity.ToTable("subscrition");
            entity.Property(e => e.SubId).ValueGeneratedNever().HasColumnName("sub_id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.DateAdd).HasColumnName("date_add");
            entity.Property(e => e.PackageId).HasColumnName("package_id");
            entity.Property(e => e.PhoneNumber).HasMaxLength(10).IsUnicode(false).HasColumnName("phone_number");

            entity.HasOne(d => d.Address).WithMany(p => p.Subscritions)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_address_id2");

            entity.HasOne(d => d.Package).WithMany(p => p.Subscritions)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_package_id2");
        });

        modelBuilder.Entity<TypeWorker>(entity =>
        {
            entity.HasKey(e => e.TypeWorkerId).HasName("PK__type_wor__A6E0C52144704B1B");
            entity.ToTable("type_worker");
            entity.Property(e => e.TypeWorkerId).ValueGeneratedNever().HasColumnName("type_worker_id");
            entity.Property(e => e.NameType).HasMaxLength(10).IsUnicode(false).HasColumnName("name_type");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("PK__worker__569F8007D7AF20AA");
            entity.ToTable("worker");
            entity.Property(e => e.WorkerId).HasMaxLength(10).IsUnicode(false).HasColumnName("worker_id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.NumForWeek).HasColumnName("num_for_week");
            entity.Property(e => e.SalaryForHour).HasColumnName("salary_for_hour");
            entity.Property(e => e.TypeWorkerId).HasColumnName("type_worker_id");

            entity.HasOne(d => d.Address).WithMany(p => p.Workers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_address_id");

            entity.HasOne(d => d.TypeWorker).WithMany(p => p.Workers)
                .HasForeignKey(d => d.TypeWorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_type_worker_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}