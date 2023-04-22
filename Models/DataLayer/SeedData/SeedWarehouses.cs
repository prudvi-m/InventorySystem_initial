using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedWarehouses : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> entity)
        {
            entity.HasData(
                new Warehouse { WarehouseId = "Chicago", Name = "chicago" },
                new Warehouse { WarehouseId = "New York", Name = "newyork" },
                new Warehouse { WarehouseId = "Los Angles", Name = "losangles" },
                new Warehouse { WarehouseId = "Washington DC", Name = "washingtondc" },
            );
        }
    }

}

// dotnet aspnet-codegenerator identity -dc InventorySystemContext create "manager" -email "manager@gmail.com" -pw "1234" -role "manager"