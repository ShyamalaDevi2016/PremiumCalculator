using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PremiumCalc.Services.Models;

namespace PremiumCalc.Services.DBContext
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OccupationRating> OccupationRating { get; set; }
        public virtual DbSet<RatingMaster> RatingMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OccupationRating>(entity =>
            {
                entity.HasKey(e => e.OccupationId);

                entity.HasIndex(e => e.OccupationName)
                    .HasName("NC_OrderByOccupationName");

                entity.Property(e => e.OccupationName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.OccupationRating)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OccupationRating_RatingMaster");
            });

            modelBuilder.Entity<RatingMaster>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.Property(e => e.Factor).HasColumnType("decimal(5, 3)");

                entity.Property(e => e.RatingName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
