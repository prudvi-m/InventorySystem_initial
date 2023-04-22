using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedWarehouses : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> entity)
        {
            entity.HasData(
                new Warehouse { WarehouseId = "chicago" , Name = "Chicago" , Code = 1234 },
                new Warehouse { WarehouseId = "newyork" , Name = "New York" , Code = 4321 },
                new Warehouse { WarehouseId = "losangles", Name = "Los Angles", Code = 5678 },
                new Warehouse { WarehouseId = "washingtondc", Name = "Washington DC", Code = 8765 }
            );
        }
    }

}

// dotnet aspnet-codegenerator identity -dc InventorySystemContext create "manager" -email "manager@gmail.com" -pw "1234" -role "manager"