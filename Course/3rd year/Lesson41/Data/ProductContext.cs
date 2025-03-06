namespace ProductAPI.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ProductAPI.Models;

public class ProductContext  : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) {}

    public DbSet<Product> Products { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(e =>
        {
            e.Property(p => p.CreatedDate)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
        
            e.HasIndex(p => p.Name)
            .HasDatabaseName("Name_idx")
            .IsUnique(false);

            e.HasIndex(p => p.Category)
            .HasDatabaseName("Category_idx")
            .IsUnique(false);

            e.HasIndex(p => new { p.Price, p.CreatedDate })
            .HasDatabaseName("IX_Products_Price_CreatedDate");
        }
    );
    }

}