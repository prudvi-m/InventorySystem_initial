using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedCategories : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category { CategoryId = 1, FirstName = "Michelle", LastName = "Alexander" },
                new Category { CategoryId = 2, FirstName = "Stephen E.", LastName = "Ambrose" },
                new Category { CategoryId = 3, FirstName = "Margaret", LastName = "Atwood" },
                new Category { CategoryId = 4, FirstName = "Jane", LastName = "Austen" },
                new Category { CategoryId = 5, FirstName = "James", LastName = "Baldwin" },
                new Category { CategoryId = 6, FirstName = "Emily", LastName = "Bronte" },
                new Category { CategoryId = 7, FirstName = "Agatha", LastName = "Christie" },
                new Category { CategoryId = 8, FirstName = "Ta-Nehisi", LastName = "Coates" },
                new Category { CategoryId = 9, FirstName = "Jared", LastName = "Diamond" },
                new Category { CategoryId = 10, FirstName = "Joan", LastName = "Didion" },
                new Category { CategoryId = 11, FirstName = "Daphne", LastName = "Du Maurier" },
                new Category { CategoryId = 12, FirstName = "Tina", LastName = "Fey" },
                new Category { CategoryId = 13, FirstName = "Roxane", LastName = "Gay" },
                new Category { CategoryId = 14, FirstName = "Dashiel", LastName = "Hammett" },
                new Category { CategoryId = 15, FirstName = "Frank", LastName = "Herbert" },
                new Category { CategoryId = 16, FirstName = "Aldous", LastName = "Huxley" },
                new Category { CategoryId = 17, FirstName = "Stieg", LastName = "Larsson" },
                new Category { CategoryId = 18, FirstName = "David", LastName = "McCullough" },
                new Category { CategoryId = 19, FirstName = "Toni", LastName = "Morrison" },
                new Category { CategoryId = 20, FirstName = "George", LastName = "Orwell" },
                new Category { CategoryId = 21, FirstName = "Mary", LastName = "Shelley" },
                new Category { CategoryId = 22, FirstName = "Sun", LastName = "Tzu" },
                new Category { CategoryId = 23, FirstName = "Augusten", LastName = "Burroughs" },
                new Category { CategoryId = 25, FirstName = "JK", LastName = "Rowling" },
                new Category { CategoryId = 26, FirstName = "Seth", LastName = "Grahame-Smith" }
            );
        }
    }

}