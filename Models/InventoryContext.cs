using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "C", Name = "Clothing" },
                new Category { CategoryId = "food", Name = "Food" },
                new Category { CategoryId = "grocery", Name = "Grocery" },
                new Category { CategoryId = "electronics", Name = "Electronics" },
                new Category { CategoryId = "home", Name = "Home" },
                new Category { CategoryId = "garden", Name = "Garden" }
            );

            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { WarehouseId = "chicago", Name = "Chicago" },
                new Warehouse { WarehouseId = "new york", Name = "New York" },
                new Warehouse { WarehouseId = "san francisco", Name = "San Francisco" },
                new Warehouse { WarehouseId = "miami", Name = "Miami" }
            );
        }
    }
}
