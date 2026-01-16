using System;
using System.Collections.Generic;
using AspNetWebApiVersionsing.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiVersionsing.Data;

public partial class LeagueManagerDbContext : DbContext
{
    public LeagueManagerDbContext()
    {
    }

    public LeagueManagerDbContext(DbContextOptions<LeagueManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerStatsCategory> PlayerStatsCategories { get; set; }

    public virtual DbSet<PlayerStatsType> PlayerStatsTypes { get; set; }

    public virtual DbSet<Stadium> Stadiums { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=PremierLeagueAppDb; Trusted_Connection=True;Encrypt=False; MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Clubs_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AddressLine1).HasMaxLength(50);
            entity.Property(e => e.AddressLine2).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())", "DF_Clubs_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.FacebookUrl).HasMaxLength(500);
            entity.Property(e => e.InstagramUrl).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhotoUrl).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.TwitterUrl).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.WebsiteUrl).HasMaxLength(500);
            entity.Property(e => e.YoutubeUrl).HasMaxLength(500);
            entity.Property(e => e.Zipcode).HasMaxLength(50);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Countries_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())", "DF_Countries_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.DisplayOrder).HasDefaultValue(1, "DF_Countries_DisplayOrder");
            entity.Property(e => e.FlagUrl).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);
            entity.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Players_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())", "DF_Players_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.DisplayOrder).HasDefaultValue(1, "DF_Players_DisplayOrder");
            entity.Property(e => e.FacebookUrl).HasMaxLength(500);
            entity.Property(e => e.InstagramUrl).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhotoUrl).HasMaxLength(50);
            entity.Property(e => e.TwitterUrl).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Club).WithMany(p => p.Players)
                .HasForeignKey(d => d.ClubId)
                .HasConstraintName("FK_Players_ClubId_Clubs_Id");

            entity.HasOne(d => d.Country).WithMany(p => p.Players)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Players_CountryId_Countries_Id");
        });

        modelBuilder.Entity<PlayerStatsCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlayerStatsCategories_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())", "DF_PlayerStatsCategories_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PlayerStatsType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlayerStatsTypes_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())", "DF_PlayerStatsTypes_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.DisplayOrder).HasDefaultValue(1, "DF_PlayerStatsTypes_DisplayOrder");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.PlayerStatsCategory).WithMany(p => p.PlayerStatsTypes)
                .HasForeignKey(d => d.PlayerStatsCategoryId)
                .HasConstraintName("FK_PlayerStatsTypes_PlayerStatsCategoryId_PlayerStatsCategories_Id");
        });

        modelBuilder.Entity<Stadium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Stadiums_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AddressLine1).HasMaxLength(50);
            entity.Property(e => e.AddressLine2).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())", "DF_Stadiums_DateCreated")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhotoUrl).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Zipcode).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Stadia)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Stadiums_CountryId_Countries_Id");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_States_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())", "DF_States_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.IsoCode).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_States_CountryId_Countries_Id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())", "DF_Users_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
