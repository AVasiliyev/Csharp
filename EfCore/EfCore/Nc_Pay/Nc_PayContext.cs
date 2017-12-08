using Microsoft.EntityFrameworkCore;

namespace EfCore.Nc_Pay
{
    public class NcPayContext : DbContext
    {
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<ChargeLogs> ChargeLogs { get; set; }
        public virtual DbSet<ChargeMetadata> ChargeMetadata { get; set; }
        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<CustomerMap> CustomerMap { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Refunds> Refunds { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(local);Database=Nc_Pay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChargeLogs>(entity =>
            {
                entity.HasIndex(e => e.ChargeId);

                entity.Property(e => e.ChargeStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Entity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.EntityId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.EntityStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.InitiatedBy)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Charge)
                    .WithMany(p => p.ChargeLogs)
                    .HasForeignKey(d => d.ChargeId);
            });

            modelBuilder.Entity<ChargeMetadata>(entity =>
            {
                entity.HasIndex(e => e.ChargeId);

                entity.Property(e => e.Key).HasMaxLength(150);

                entity.HasOne(d => d.Charge)
                    .WithMany(p => p.ChargeMetadata)
                    .HasForeignKey(d => d.ChargeId);
            });

            modelBuilder.Entity<Charge>(entity =>
            {
                entity.HasIndex(e => e.ExternalOrderId);

                entity.HasIndex(e => e.TransactionId);

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ExternalOrderId).HasMaxLength(150);

                entity.Property(e => e.InitialAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).IsRowVersion();

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Charges)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CustomerMap>(entity =>
            {
                entity.HasKey(e => new { e.Name, e.AccountId });
            });

            modelBuilder.Entity<Refunds>(entity =>
            {
                entity.HasIndex(e => e.ChargeId);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).IsRowVersion();

                entity.HasOne(d => d.Charge)
                    .WithMany(p => p.Refunds)
                    .HasForeignKey(d => d.ChargeId);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.ExternalId).HasMaxLength(500);

                entity.Property(e => e.Timestamp).IsRowVersion();
            });
        }
    }
}
