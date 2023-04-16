using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedWarehouses : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> entity)
        {
            entity.HasData(
                new Warehouse { WarehouseId = "novel", Name = "Novel" },
                new Warehouse { WarehouseId = "memoir", Name = "Memoir" },
                new Warehouse { WarehouseId = "mystery", Name = "Mystery" },
                new Warehouse { WarehouseId = "scifi", Name = "Science Fiction" },
                new Warehouse { WarehouseId = "history", Name = "History" }
            );
        }
    }

}

// dotnet aspnet-codegenerator identity -dc InventorySystemContext create "manager" -email "manager@gmail.com" -pw "1234" -role "manager"