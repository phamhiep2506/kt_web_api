using Microsoft.EntityFrameworkCore;

namespace Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<ProductDetail>? ProductDetails { get; set; }
    public DbSet<ProductDetailPropertyDetail>? ProductDetailPropertyDetails { get; set; }
    public DbSet<Propertie>? Properties { get; set; }
    public DbSet<PropertyDetail>? PropertyDetails { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}
