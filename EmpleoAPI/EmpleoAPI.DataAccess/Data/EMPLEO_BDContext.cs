using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmpleoAPI
{
    public partial class EMPLEO_BDContext : DbContext
    {
        public EMPLEO_BDContext()
        {
        }

        public EMPLEO_BDContext(DbContextOptions<EMPLEO_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("CITY");

                entity.Property(e => e.Code).HasColumnName("CODE");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("SELLER");

                entity.Property(e => e.Code).HasColumnName("CODE");

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("DOCUMENT");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SELLER_CITY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
