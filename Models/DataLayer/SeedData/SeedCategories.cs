using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedCategories : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category { CategoryId = 1, Name = "Michelle" },
                new Category { CategoryId = 2, Name = "Stephen E." },
                new Category { CategoryId = 3, Name = "Margaret" },
                new Category { CategoryId = 4, Name = "Jane" },
                new Category { CategoryId = 5, Name = "James" },
                new Category { CategoryId = 6, Name = "Emily" },
                new Category { CategoryId = 7, Name = "Agatha" },
                new Category { CategoryId = 8, Name = "Ta-Nehisi" },
                new Category { CategoryId = 9, Name = "Jared" },
                new Category { CategoryId = 10, Name = "Joan" },
                new Category { CategoryId = 11, Name = "Daphne", },
                new Category { CategoryId = 12, Name = "Tina" },
                new Category { CategoryId = 13, Name = "Roxane" },
                new Category { CategoryId = 14, Name = "Dashiel" },
                new Category { CategoryId = 15, Name = "Frank" },
                new Category { CategoryId = 16, Name = "Aldous" },
                new Category { CategoryId = 17, Name = "Stieg" },
                new Category { CategoryId = 18, Name = "David" },
                new Category { CategoryId = 19, Name = "Toni" },
                new Category { CategoryId = 20, Name = "George" },
                new Category { CategoryId = 21, Name = "Mary" },
                new Category { CategoryId = 22, Name = "Sun" },
                new Category { CategoryId = 23, Name = "Augusten" },
                new Category { CategoryId = 25, Name = "JK" },
                new Category { CategoryId = 26, Name = "Seth" }
            );
     }
 }
}