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
                new Product { ProductId = 10, Name = "Down and Out in Paris and London", WarehouseId = "chicago", Price = 12.50 },
                new Product { ProductId = 11, Name = "Dune", WarehouseId = "newyork", Price = 8.75 },
                new Product { ProductId = 12, Name = "Emma", WarehouseId = "washingtondc", Price = 9.00 },
                new Product { ProductId = 13, Name = "Frankenstein", WarehouseId = "newyork", Price = 6.50D },
                new Product { ProductId = 14, Name = "Go Tell it on the Mountain", WarehouseId = "washingtondc", Price = 10.25 },
                new Product { ProductId = 15, Name = "Guns, Germs, and Steel", WarehouseId = "chicago", Price = 15.50 },
                new Product { ProductId = 16, Name = "Hunger", WarehouseId = "chicago", Price = 14.50 },
                new Product { ProductId = 17, Name = "Murder on the Orient Express", WarehouseId = "losangles", Price = 6.75 },
                new Product { ProductId = 18, Name = "Pride and Prejudice", WarehouseId = "washingtondc", Price = 8.50 },
                new Product { ProductId = 19, Name = "Rebecca", WarehouseId = "losangles", Price = 10.99 },
                new Product { ProductId = 20, Name = "The Art of War", WarehouseId = "chicago", Price = 5.75 },
                new Product { ProductId = 21, Name = "The Girl with the Dragon Tattoo", WarehouseId = "losangles", Price = 8.50 },
                new Product { ProductId = 22, Name = "The Handmaid's Tale", WarehouseId = "newyork", Price = 12.50 },
                new Product { ProductId = 23, Name = "The Maltese Falcon", WarehouseId = "losangles", Price = 10.99 },
                new Product { ProductId = 24, Name = "The New Jim Crow", WarehouseId = "chicago", Price = 13.75 },
                new Product { ProductId = 25, Name = "The Year of Magical Thinking", WarehouseId = "chicago", Price = 13.50 },
                new Product { ProductId = 26, Name = "Wuthering Heights", WarehouseId = "washingtondc", Price = 9.00 },
                new Product { ProductId = 27, Name = "Running With Scissors", WarehouseId = "chicago", Price = 11.00 },
                new Product { ProductId = 28, Name = "Pride and Prejudice and Zombies", WarehouseId = "washingtondc", Price = 8.75 },
                new Product { ProductId = 29, Name = "Harry Potter and the Sorcerer's Stone", WarehouseId = "washingtondc", Price = 9.75 }
            );
        }
    }

}
