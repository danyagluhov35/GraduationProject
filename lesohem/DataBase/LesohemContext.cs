using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lesohem.DataBase;

public partial class LesohemContext : DbContext
{
    public LesohemContext()
    {
    }

    public LesohemContext(DbContextOptions<LesohemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<SocMedium> SocMedia { get; set; }

    public virtual DbSet<TableBlock> TableBlocks { get; set; }

    public virtual DbSet<TableContent> TableContents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\LocalDBDemo;Database=lesohem;Trusted_Connection=True;TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("City");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Country");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Direction");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Group");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SocMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("FK_Media_Id");

            entity.Property(e => e.Mname)
                .HasMaxLength(20)
                .HasColumnName("MName");

            entity.HasOne(d => d.Person).WithMany(p => p.SocMedia)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_Media_User");
        });

        modelBuilder.Entity<TableBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TableBlo__3214EC07A4BCA817");

            entity.ToTable("TableBlock");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TableContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TableCon__3214EC0718F3FB78");

            entity.ToTable("TableContent");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.TableBlock).WithMany(p => p.TableContents)
                .HasForeignKey(d => d.TableBlockId)
                .HasConstraintName("FK_TableContent_To_TableBlock");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User_Id");

            entity.ToTable("User");

            entity.HasIndex(e => e.UserLogin, "UQ_User_userLogin").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CityName).HasMaxLength(50);
            entity.Property(e => e.CountryName).HasMaxLength(50);
            entity.Property(e => e.DirectionName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.GroupName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SurName).HasMaxLength(50);
            entity.Property(e => e.UserLogin)
                .HasMaxLength(20)
                .HasColumnName("userLogin");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(20)
                .HasColumnName("userPassword");
            entity.Property(e => e.UserRole)
                .HasMaxLength(20)
                .HasColumnName("userRole");

            entity.HasOne(d => d.CityNameNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.CityName)
                .HasConstraintName("FK_User_City");

            entity.HasOne(d => d.CountryNameNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.CountryName)
                .HasConstraintName("FK_User_Country");

            entity.HasOne(d => d.DirectionNameNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.DirectionName)
                .HasConstraintName("FK_User_Direction");

            entity.HasOne(d => d.GroupNameNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.GroupName)
                .HasConstraintName("FK_User_Group");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
