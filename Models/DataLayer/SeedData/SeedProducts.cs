using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(
                new Product { ProductId = 1, Title = "1776", WarehouseId = "history", Price = 18.00 },
                new Product { ProductId = 2, Title = "1984", WarehouseId = "scifi", Price = 5.50 },
                new Product { ProductId = 3, Title = "And Then There Were None", WarehouseId = "mystery", Price = 4.50 },
                new Product { ProductId = 4, Title = "Band of Brothers", WarehouseId = "history", Price = 11.50 },
                new Product { ProductId = 5, Title = "Beloved", WarehouseId = "novel", Price = 10.99 },
                new Product { ProductId = 6, Title = "Between the World and Me", WarehouseId = "memoir", Price = 13.50 },
                new Product { ProductId = 7, Title = "Bossypants", WarehouseId = "memoir", Price = 4.25 },
                new Product { ProductId = 8, Title = "Brave New World", WarehouseId = "scifi", Price = 16.25 },
                new Product { ProductId = 9, Title = "D-Day", WarehouseId = "history", Price = 15.00 },
                new Product { ProductId = 10, Title = "Down and Out in Paris and London", WarehouseId = "memoir", Price = 12.50 },
                new Product { ProductId = 11, Title = "Dune", WarehouseId = "scifi", Price = 8.75 },
                new Product { ProductId = 12, Title = "Emma", WarehouseId = "novel", Price = 9.00 },
                new Product { ProductId = 13, Title = "Frankenstein", WarehouseId = "scifi", Price = 6.50D },
                new Product { ProductId = 14, Title = "Go Tell it on the Mountain", WarehouseId = "novel", Price = 10.25 },
                new Product { ProductId = 15, Title = "Guns, Germs, and Steel", WarehouseId = "history", Price = 15.50 },
                new Product { ProductId = 16, Title = "Hunger", WarehouseId = "memoir", Price = 14.50 },
                new Product { ProductId = 17, Title = "Murder on the Orient Express", WarehouseId = "mystery", Price = 6.75 },
                new Product { ProductId = 18, Title = "Pride and Prejudice", WarehouseId = "novel", Price = 8.50 },
                new Product { ProductId = 19, Title = "Rebecca", WarehouseId = "mystery", Price = 10.99 },
                new Product { ProductId = 20, Title = "The Art of War", WarehouseId = "history", Price = 5.75 },
                new Product { ProductId = 21, Title = "The Girl with the Dragon Tattoo", WarehouseId = "mystery", Price = 8.50 },
                new Product { ProductId = 22, Title = "The Handmaid's Tale", WarehouseId = "scifi", Price = 12.50 },
                new Product { ProductId = 23, Title = "The Maltese Falcon", WarehouseId = "mystery", Price = 10.99 },
                new Product { ProductId = 24, Title = "The New Jim Crow", WarehouseId = "history", Price = 13.75 },
                new Product { ProductId = 25, Title = "The Year of Magical Thinking", WarehouseId = "memoir", Price = 13.50 },
                new Product { ProductId = 26, Title = "Wuthering Heights", WarehouseId = "novel", Price = 9.00 },
                new Product { ProductId = 27, Title = "Running With Scissors", WarehouseId = "memoir", Price = 11.00 },
                new Product { ProductId = 28, Title = "Pride and Prejudice and Zombies", WarehouseId = "novel", Price = 8.75 },
                new Product { ProductId = 29, Title = "Harry Potter and the Sorcerer's Stone", WarehouseId = "novel", Price = 9.75 }
            );
        }
    }

}
