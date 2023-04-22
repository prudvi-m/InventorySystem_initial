using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedWarehouses : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> entity)
        {
            entity.HasData(
                new Warehouse { WarehouseId = "Chicago", Name = "chicago" , Code = 1234 },
                new Warehouse { WarehouseId = "New York", Name = "newyork" , Code = 4321 },
                new Warehouse { WarehouseId = "Los Angles", Name = "losangles", Code = 5678 },
                new Warehouse { WarehouseId = "Washington DC", Name = "washingtondc", Code = 8765 }
            );
        }
    }

}

// dotnet aspnet-codegenerator identity -dc InventorySystemContext create "manager" -email "manager@gmail.com" -pw "1234" -role "manager"