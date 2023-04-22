using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedCategories : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category { CategoryId = 1, Name = "Michelle", Name = "Alexander" },
                new Category { CategoryId = 2, Name = "Stephen E.", Name = "Ambrose" },
                new Category { CategoryId = 3, Name = "Margaret", Name = "Atwood" },
                new Category { CategoryId = 4, Name = "Jane", Name = "Austen" },
                new Category { CategoryId = 5, Name = "James", Name = "Baldwin" },
                new Category { CategoryId = 6, Name = "Emily", Name = "Bronte" },
                new Category { CategoryId = 7, Name = "Agatha", Name = "Christie" },
                new Category { CategoryId = 8, Name = "Ta-Nehisi", Name = "Coates" },
                new Category { CategoryId = 9, Name = "Jared", Name = "Diamond" },
                new Category { CategoryId = 10, Name = "Joan", Name = "Didion" },
                new Category { CategoryId = 11, Name = "Daphne", Name = "Du Maurier" },
                new Category { CategoryId = 12, Name = "Tina", Name = "Fey" },
                new Category { CategoryId = 13, Name = "Roxane", Name = "Gay" },
                new Category { CategoryId = 14, Name = "Dashiel", Name = "Hammett" },
                new Category { CategoryId = 15, Name = "Frank", Name = "Herbert" },
                new Category { CategoryId = 16, Name = "Aldous", Name = "Huxley" },
                new Category { CategoryId = 17, Name = "Stieg", Name = "Larsson" },
                new Category { CategoryId = 18, Name = "David", Name = "McCullough" },
                new Category { CategoryId = 19, Name = "Toni", Name = "Morrison" },
                new Category { CategoryId = 20, Name = "George", Name = "Orwell" },
                new Category { CategoryId = 21, Name = "Mary", Name = "Shelley" },
                new Category { CategoryId = 22, Name = "Sun", Name = "Tzu" },
                new Category { CategoryId = 23, Name = "Augusten", Name = "Burroughs" },
                new Category { CategoryId = 25, Name = "JK", Name = "Rowling" },
                new Category { CategoryId = 26, Name = "Seth", Name = "Grahame-Smith" }
            );
        }
    }

}