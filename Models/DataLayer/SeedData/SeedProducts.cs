using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(
                new Product { ProductId = 1, Name = "1776", WarehouseId = "chicago", Price = 18.00 },
                new Product { ProductId = 2, Name = "1984", WarehouseId = "newyork", Price = 5.50 },
                new Product { ProductId = 3, Name = "And Then There Were None", WarehouseId = "losangles", Price = 4.50 },
                new Product { ProductId = 4, Name = "Band of Brothers", WarehouseId = "chicago", Price = 11.50 },
                new Product { ProductId = 5, Name = "Beloved", WarehouseId = "washingtondc", Price = 10.99 },
                new Product { ProductId = 6, Name = "Between the World and Me", WarehouseId = "chicago", Price = 13.50 },
                new Product { ProductId = 7, Name = "Bossypants", WarehouseId = "chicago", Price = 4.25 },
                new Product { ProductId = 8, Name = "Brave New World", WarehouseId = "newyork", Price = 16.25 },
                new Product { ProductId = 9, Name = "D-Day", WarehouseId = "chicago", Price = 15.00 },
                new Product { ProductId = 10, Name = "Down and Out in Paris and London", WarehouseId = "chicago", Price = 12.50 }
            );
        }
    }

}
