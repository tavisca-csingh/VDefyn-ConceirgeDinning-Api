using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConceirgeDiningDAL.Models
{
    public partial class ConciergeContext : DbContext
    {
        public ConciergeContext()
        {
        }

        public ConciergeContext(DbContextOptions<ConciergeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingProgress> BookingProgress { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<RestaurantAvailability> RestaurantAvailability { get; set; }
        public virtual DbSet<RestaurantNames> RestaurantNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=Concierge;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.LoyaltyPoints).HasColumnName("loyaltyPoints");

                entity.Property(e => e.RestaurantId)
                    .IsRequired()
                    .HasColumnName("restaurantId")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seats).HasColumnName("seats");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__restaur__251C81ED");
            });

            modelBuilder.Entity<BookingProgress>(entity =>
            {
                entity.HasKey(e => e.BookingProgreeId)
                    .HasName("PK__BookingP__42F797D76A7D7E34");

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion();

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingProgress)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookingPr__Booki__2610A626");
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PK__LoginInf__23DB122B87A68AE8");

                entity.Property(e => e.SessionId).HasColumnName("sessionId");

                entity.Property(e => e.Bank)
                    .IsRequired()
                    .HasColumnName("bank")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasColumnName("locale")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LoyaltyPoints).HasColumnName("loyaltyPoints");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RestaurantAvailability>(entity =>
            {
                entity.HasKey(e => new { e.RestaurantId, e.BookingDate })
                    .HasName("PK__Restaura__FA9480A9E17F949F");

                entity.Property(e => e.RestaurantId)
                    .HasColumnName("restaurantId")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BookingDate).HasColumnType("date");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantAvailability)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__resta__2704CA5F");
            });

            modelBuilder.Entity<RestaurantNames>(entity =>
            {
                entity.HasKey(e => e.RestaurantId)
                    .HasName("PK__Restaura__87454C95FB55B7BD");

                entity.Property(e => e.RestaurantId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.RestaurantName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
