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

               // optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=BMSDB;User ID=sa;Password=123456;Trusted_Connection=True;");
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

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Book_Category");
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

                entity.HasOne(d => d.Borrower)
                    .WithMany(p => p.BorrowTicketBorrowers)
                    .HasForeignKey(d => d.BorrowerId)
                    .HasConstraintName("FK_BorrowTicket_User1");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.BorrowTicketCreators)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("FK_BorrowTicket_User");
            });

            modelBuilder.Entity<BorrowTicketDetail>(entity =>
            {
                entity.ToTable("BorrowTicketDetail");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BorrowTicketDetails)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BorrowTicketDetail_Book");

                entity.HasOne(d => d.BorrowTicket)
                    .WithMany(p => p.BorrowTicketDetails)
                    .HasForeignKey(d => d.BorrowTicketId)
                    .HasConstraintName("FK_BorrowTicketDetail_BorrowTicket");
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
