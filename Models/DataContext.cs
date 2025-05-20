using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new List<Category> {
                    new Category { CategoryId = 1, CategoryName = "Koltuk" },
                    new Category { CategoryId = 2, CategoryName = "Masa" },
                    new Category { CategoryId = 3, CategoryName = "Sandalye" },
                    new Category { CategoryId = 4, CategoryName = "Sehpa" },
                    new Category { CategoryId = 5, CategoryName = "Dolap" }
                }
            );

            modelBuilder.Entity<Product>().HasData(
            new List<Product> {
                    new Product {
                        ProductId = 1,
                        Name = "İskandinav Koltuk",
                        Description = "Minimalist tarzda, rahat oturumlu 3 kişilik koltuk.",
                        Price = 1000,
                        ImageUrl = "/images/koltuk.jpg",
                        CategoryId = 1
                    },
                    new Product {
                        ProductId = 2,
                        Name = "Doğal Ahşap Masa",
                        Description = "Masif meşe ağacından üretilmiş 6 kişilik yemek masası.",
                        Price = 1000,
                        ImageUrl = "/images/masa.jpg",
                        CategoryId = 2
                    },
                    new Product {
                        ProductId = 3,
                        Name = "Sandalye",
                        Description = "Ergonomik oturumlu, modern tarzda sandalye.",
                        Price = 800,
                        ImageUrl = "/images/sandalye.jpg",
                        CategoryId = 3
                    },
                    new Product {
                        ProductId = 4,
                        Name = "Kare Ahşap Sehpa",
                        Description = "Orta sehpa olarak kullanılabilecek modern yuvarlak sehpa.",
                        Price = 700,
                        ImageUrl = "/images/sehpa.jpg",
                        CategoryId = 4
                    },
                    new Product {
                        ProductId = 5,
                        Name = "Minimal Dolap",
                        Description = "Küçük alanlar için ideal, sade tasarımlı dolap.",
                        Price = 1200,
                        ImageUrl = "/images/dolap.jpg",
                        CategoryId = 5
                    }
            }
        );

            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    SliderId = 1,
                    Title = "Modern Yaşam Alanları",
                    Description = "Evini yenilemek için ilham verici mobilyalar",
                    ImageUrl = "/images/slider1.jpg",
                    DisplayIndex = 0,
                    IsActive = true
                },
                new Slider
                {
                    SliderId = 2,
                    Title = "Konfor & Şıklık",
                    Description = "En çok tercih edilen koltuk ve masa takımları burada",
                    ImageUrl = "/images/slider2.jpg",
                    DisplayIndex = 1,
                    IsActive = true
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", Password = "1234", Role="admin" },
                new User { UserId = 2, Username = "begum", Password = "5678", Role="user"}
            );
        }
    }
}