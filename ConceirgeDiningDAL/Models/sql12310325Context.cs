using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConceirgeDiningDAL.Models
{
    public partial class sql12310325Context : DbContext
    {
        public sql12310325Context()
        {
        }

        public sql12310325Context(DbContextOptions<sql12310325Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingProgress> BookingProgress { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientCallLogs> ClientCallLogs { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Ordering> Ordering { get; set; }
        public virtual DbSet<RestaurantAvailability> RestaurantAvailability { get; set; }
        public virtual DbSet<RestaurantNames> RestaurantNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=sql12.freesqldatabase.com;Database=sql12310325;Uid=sql12310325;Pwd=wR3wJZe8VG;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking", "sql12310325");

                entity.HasIndex(e => e.RestaurantId)
                    .HasName("restaurantId");

                entity.Property(e => e.BookingId).HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.LoyaltyPoints)
                    .HasColumnName("loyaltyPoints")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PointPricePerPerson).HasColumnType("bigint(20)");

                entity.Property(e => e.RestaurantId)
                    .IsRequired()
                    .HasColumnName("restaurantId")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seats)
                    .HasColumnName("seats")
                    .HasColumnType("int(11)");

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

                entity.Property(e => e.Utctime)
                    .IsRequired()
                    .HasColumnName("UTCTime")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("\"0001-01-01T00:00:00+00:00\"");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Booking_ibfk_1");
            });

            modelBuilder.Entity<BookingProgress>(entity =>
            {
                entity.HasKey(e => e.BookingProgreeId);

                entity.ToTable("BookingProgress", "sql12310325");

                entity.HasIndex(e => e.BookingId)
                    .HasName("BookingId");

                entity.Property(e => e.BookingProgreeId).HasColumnType("int(11)");

                entity.Property(e => e.BookingId).HasColumnType("int(11)");

                entity.Property(e => e.TimeStamp).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingProgress)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BookingProgress_ibfk_1");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Apikey);

                entity.ToTable("Client", "sql12310325");

                entity.HasIndex(e => e.ClientName)
                    .HasName("clientName")
                    .IsUnique();

                entity.Property(e => e.Apikey)
                    .HasColumnName("APIkey")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("clientName")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientCallLogs>(entity =>
            {
                entity.HasKey(e => new { e.Apikey, e.Date });

                entity.ToTable("ClientCallLogs", "sql12310325");

                entity.HasIndex(e => e.Apikey)
                    .HasName("APIkey");

                entity.Property(e => e.Apikey)
                    .HasColumnName("APIkey")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Calls)
                    .HasColumnName("calls")
                    .HasColumnType("bigint(255)");

                entity.HasOne(d => d.ApikeyNavigation)
                    .WithMany(p => p.ClientCallLogs)
                    .HasForeignKey(d => d.Apikey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FOREIGN");
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.SessionId);

                entity.ToTable("LoginInfo", "sql12310325");

                entity.Property(e => e.SessionId)
                    .HasColumnName("sessionId")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bank)
                    .IsRequired()
                    .HasColumnName("bank")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Environment)
                    .IsRequired()
                    .HasColumnName("environment")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasColumnName("locale")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.LoyaltyPoints)
                    .HasColumnName("loyaltyPoints")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Timestamp).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemName });

                entity.ToTable("OrderDetails", "sql12310325");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10,5)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderDetails_ibfk_1");
            });

            modelBuilder.Entity<Ordering>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Ordering", "sql12310325");

                entity.HasIndex(e => e.RestaurantId)
                    .HasName("restaurantId");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.Property(e => e.RestaurantId)
                    .IsRequired()
                    .HasColumnName("restaurantId")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TotalPoints).HasColumnType("bigint(20)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Ordering)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ordering_ibfk_1");
            });

            modelBuilder.Entity<RestaurantAvailability>(entity =>
            {
                entity.HasKey(e => new { e.RestaurantId, e.BookingDate });

                entity.ToTable("RestaurantAvailability", "sql12310325");

                entity.Property(e => e.RestaurantId)
                    .HasColumnName("restaurantId")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BookingDate).HasColumnType("date");

                entity.Property(e => e.BookedSeats).HasColumnType("int(11)");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantAvailability)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RestaurantAvailability_ibfk_1");
            });

            modelBuilder.Entity<RestaurantNames>(entity =>
            {
                entity.HasKey(e => e.RestaurantId);

                entity.ToTable("RestaurantNames", "sql12310325");

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
