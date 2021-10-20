using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookManagementSystemData.Models
{
    public partial class BMSDBContext : DbContext
    {
        public BMSDBContext()
        {
        }

        public BMSDBContext(DbContextOptions<BMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BorrowTicket> BorrowTickets { get; set; }
        public virtual DbSet<BorrowTicketDetail> BorrowTicketDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=BMSDB;User ID=sa;Password=123456;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BorrowTicket>(entity =>
            {
                entity.ToTable("BorrowTicket");

                entity.Property(e => e.BorrowDate).HasColumnType("datetime");

                entity.Property(e => e.BorrowerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BorrowerID");

                entity.Property(e => e.CreatorId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnDeadline).HasColumnType("date");
            });

            modelBuilder.Entity<BorrowTicketDetail>(entity =>
            {
                entity.ToTable("BorrowTicketDetail");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
