using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Slider> Sliders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Category>().HasData(
            new List<Category> {
                new Category { CategoryId = 1, CategoryName = "Aydınlatma" },
                new Category { CategoryId = 2, CategoryName = "Saat" },
                new Category { CategoryId = 3, CategoryName = "Saksı" },
                new Category { CategoryId = 4, CategoryName = "Mumluk" },
                new Category { CategoryId = 5, CategoryName = "Tütsülük" }
            }
        );

        modelBuilder.Entity<Product>().HasData(
            new List<Product> {
                new Product {
                    ProductId = 1,
                    Name = "Masa Lambası",
                    Description = "Modern tasarımlı masa lambası.",
                    Price = 1000,
                    ImageUrl = "/images/masa-lambasi1.jpg",
                    CategoryId = 1
                },
                new Product {
                    ProductId = 2,
                    Name = "Spiral Masa Lambası",
                    Description = "Modern tasarımlı masa lambası.",
                    Price = 1000,
                    ImageUrl = "/images/spiral-masa-lambasi.jpg",
                    CategoryId = 1
                }
            }
        );

        modelBuilder.Entity<Slider>().HasData(
    new Slider
    {
        SliderId = 1,
        Title = "Modern ve Minimal",
        Description = "Dekoratif ürünlerde modern çizgiler",
        ImageUrl = "/images/slider1.png",
        DisplayIndex = 0,
        IsActive = true
    },
    new Slider
    {
        SliderId = 2,
        Title = "Fonksiyonel Tasarımlar",
        Description = "Favori ürünleri keşfet",
        ImageUrl = "/images/slider2.png",
        DisplayIndex = 1,
        IsActive = true
    }
);
    }
}