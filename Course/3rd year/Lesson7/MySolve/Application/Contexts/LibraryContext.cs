using MySolve.Domain;

using Microsoft.EntityFrameworkCore;

namespace MySolve.Application.Contexts;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {}

    public DbSet<Book> Books{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.Id);
    }
}