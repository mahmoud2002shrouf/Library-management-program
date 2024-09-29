using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace projectLibary;

public partial class LibaryContext : DbContext
{
    public LibaryContext()
    {

    }

    public LibaryContext(DbContextOptions<LibaryContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Librarian> librarians { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Staff> staff { get; set; }
    public DbSet<Studant> studants { get; set; }
    public DbSet<LibraryDataBase> LibraryDataBase { get; set; }







    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseSqlServer("Server=MAHMOUD-SHROUF\\SQLEXPRESS;Database=dataLibary;Trusted_Connection=True;TrustServerCertificate=True");

        optionsBuilder.EnableSensitiveDataLogging(); 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Account>()
       .HasOne(a => a.user)
       .WithOne(u => u.account)
       .HasForeignKey<Account>(a => a.UserId);  // يتم تحديد UserId كمفتاح أجنبي في جدول Account

        modelBuilder.Entity<User>()
            .HasOne(u => u.account)
            .WithOne(a => a.user)
            .HasForeignKey<User>(u => u.AccountId);

        modelBuilder.Entity<Librarian>()
      .HasOne(a => a.LibraryDataBase)
      .WithOne(u => u.Librarian)
      .HasForeignKey<LibraryDataBase>(u => u.ID_librarian);

        modelBuilder.Entity<Book>()
      .HasOne(a => a.LibraryDataBase)
      .WithMany(u => u.ListOfBooks)
      .HasForeignKey(a => a.ldb_id)
      .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Book>()
           .HasOne(b => b.User)
           .WithMany(u => u.Books)
           .HasForeignKey(b => b.UserId)
      .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Book>()
       .HasOne(b => b.Librarian)
       .WithMany(l => l.Books)
       .HasForeignKey(b => b.ID_librarian)
      .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Account>()
    .HasOne(a => a.LibraryDataBase)
    .WithMany(l => l.Accounts)
    .HasForeignKey(a => a.ldb_id)
      .OnDelete(DeleteBehavior.Restrict);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
