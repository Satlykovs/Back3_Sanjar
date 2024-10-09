using MySolve.Domain;

using Microsoft.EntityFrameworkCore;

namespace MySolve.Application.Contexts;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) {}

    public DbSet<User> Users{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
    }
}