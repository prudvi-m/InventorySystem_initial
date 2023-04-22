using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedCategories : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category { CategoryId = 1, Name = "Food" },
                new Category { CategoryId = 2, Name = "Stationary" },
                new Category { CategoryId = 3, Name = "Grocery" },
                new Category { CategoryId = 4, Name = "Electronic" }
            );
     }
 }
}