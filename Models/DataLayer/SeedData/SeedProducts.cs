using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(
                new Product { Code=1001,Vendor = "7-Eleven", Quantity=10,ProductId = 1, Name = "Eggs", WarehouseId = "chicago", Price = 4.29 },
                new Product { Code=1002,Vendor = "H-mart", Quantity=15,ProductId = 2, Name = "Bread", WarehouseId = "newyork", Price = 2.50 },
                new Product { Code=1003,Vendor = "Marianois", Quantity=5,ProductId = 3, Name = "Dish Liquid", WarehouseId = "losangles", Price = 5.50 },
                new Product { Code=2001,Vendor = "CVS", Quantity=10,ProductId = 4, Name = "Tylenol", WarehouseId = "chicago", Price = 9.50 },
                new Product { Code=3001,Vendor = "Guess", Quantity=11,ProductId = 5, Name = "Shirt", WarehouseId = "washingtondc", Price = 23.99 },
                new Product { Code=2002,Vendor = "CVS", Quantity=8,ProductId = 6, Name = "Claritin", WarehouseId = "chicago", Price = 15.19 },
                new Product { Code=3001,Vendor = "H&M", Quantity=10,ProductId = 7, Name = "Pant", WarehouseId = "chicago", Price = 29.25 },
                new Product { Code=4010,Vendor = "Apple", Quantity=3,ProductId = 8, Name = "Mobile Phones", WarehouseId = "newyork", Price = 499.99 },
                new Product { Code=4002,Vendor = "Samsung", Quantity=7,ProductId = 9, Name = "Smart Watch", WarehouseId = "chicago", Price = 149.99 },
                new Product { Code=3001,Vendor = "Walgreens", Quantity=15,ProductId = 10, Name = "NyQuill", WarehouseId = "chicago", Price = 5.59 }
            );
        }
    }

}
