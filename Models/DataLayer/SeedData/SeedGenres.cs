using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedGenres : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> entity)
        {
            entity.HasData(
                new Warehouse { GenreId = "novel", Name = "Novel" },
                new Warehouse { GenreId = "memoir", Name = "Memoir" },
                new Warehouse { GenreId = "mystery", Name = "Mystery" },
                new Warehouse { GenreId = "scifi", Name = "Science Fiction" },
                new Warehouse { GenreId = "history", Name = "History" }
            );
        }
    }

}

// dotnet aspnet-codegenerator identity -dc InventorySystemContext create "manager" -email "manager@gmail.com" -pw "1234" -role "manager"