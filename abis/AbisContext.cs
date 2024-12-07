using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace abis;

public partial class AbisContext : DbContext
{
    public AbisContext()
    {
    }

    public AbisContext(DbContextOptions<AbisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookHistory> BookHistories { get; set; }

    public virtual DbSet<BookReader> BookReaders { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    public virtual DbSet<ReaderHistory> ReaderHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WIN-4E7JKGBR3SV\\SQLEXPRESS;Database=abis;TrustServerCertificate=True;Encrypt=False;user id=sa;password=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn);

            entity.ToTable("Book");

            entity.HasIndex(e => e.Quantity, "Book_Qauntity_Ind");

            entity.HasIndex(e => e.Title, "Book_Title_Ind");

            entity.Property(e => e.Isbn)
                .ValueGeneratedNever()
                .HasColumnName("ISBN");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Author).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.PublishingHouse).HasMaxLength(200);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<BookHistory>(entity =>
        {
            entity.HasKey(e => e.BookIsbn);

            entity.ToTable("BookHistory");

            entity.Property(e => e.BookIsbn)
                .ValueGeneratedNever()
                .HasColumnName("BookISBN");
            entity.Property(e => e.Action)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OperationId).HasColumnName("OperationID");

            entity.HasOne(d => d.BookIsbnNavigation).WithOne(p => p.BookHistory)
                .HasForeignKey<BookHistory>(d => d.BookIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book-BookHistory");
        });

        modelBuilder.Entity<BookReader>(entity =>
        {
            entity.ToTable("Book_Reader");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookIsbn).HasColumnName("BookISBN");

            entity.HasOne(d => d.BookIsbnNavigation).WithMany(p => p.BookReaders)
                .HasForeignKey(d => d.BookIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book-Book_Reader");

            entity.HasOne(d => d.ReaderGradebookNumNavigation).WithMany(p => p.BookReaders)
                .HasForeignKey(d => d.ReaderGradebookNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reader-Book_Reader");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.GradebookNum);

            entity.ToTable("Reader");

            entity.HasIndex(e => e.GroupNum, "Reader_GroupNum_Ind");

            entity.HasIndex(e => e.Surname, "Reader_Surname_Ind");

            entity.Property(e => e.GradebookNum).ValueGeneratedNever();
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Surname).HasMaxLength(20);
        });

        modelBuilder.Entity<ReaderHistory>(entity =>
        {
            entity.HasKey(e => e.ReaderGradebookNum);

            entity.ToTable("ReaderHistory");

            entity.Property(e => e.ReaderGradebookNum).ValueGeneratedNever();
            entity.Property(e => e.Action)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OperationId).HasColumnName("OperationID");

            entity.HasOne(d => d.ReaderGradebookNumNavigation).WithOne(p => p.ReaderHistory)
                .HasForeignKey<ReaderHistory>(d => d.ReaderGradebookNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reader-ReaderHistory");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
