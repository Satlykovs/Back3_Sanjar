using Microsoft.EntityFrameworkCore;

public class DeliveryContext : DbContext
{
    public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options) {}

    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers{ get; set; }
    public DbSet<Product> Products{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}