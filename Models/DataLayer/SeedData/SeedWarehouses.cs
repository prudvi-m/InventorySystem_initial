using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedWarehouses : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> entity)
        {
            entity.HasData(
                new Warehouse { Phone="3124325369",Email="adamdartey@outlook.com",ContactPerson="Adam",WarehouseId = "chicago" , Name = "Chicago" , Code = 1234 },
                new Warehouse { Phone="3124563211",Email="eddievuhu@gmail.com",ContactPerson="Eddie",WarehouseId = "newyork" , Name = "New York" , Code = 4321 },
                new Warehouse { Phone="3313313232",Email="tmartil@yahoo.in",ContactPerson="Martil",WarehouseId = "losangles", Name = "Los Angles", Code = 5678 },
                new Warehouse { Phone="3123123121",Email="johnh@hotmail.com",ContactPerson="John",WarehouseId = "washingtondc", Name = "Washington DC", Code = 8765 }
            );
        }
    }

}

// dotnet aspnet-codegenerator identity -dc InventorySystemContext create "manager" -email "manager@gmail.com" -pw "1234" -role "manager"