using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedCategories : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category { AuthorId = 1, FirstName = "Michelle", LastName = "Alexander" },
                new Category { AuthorId = 2, FirstName = "Stephen E.", LastName = "Ambrose" },
                new Category { AuthorId = 3, FirstName = "Margaret", LastName = "Atwood" },
                new Category { AuthorId = 4, FirstName = "Jane", LastName = "Austen" },
                new Category { AuthorId = 5, FirstName = "James", LastName = "Baldwin" },
                new Category { AuthorId = 6, FirstName = "Emily", LastName = "Bronte" },
                new Category { AuthorId = 7, FirstName = "Agatha", LastName = "Christie" },
                new Category { AuthorId = 8, FirstName = "Ta-Nehisi", LastName = "Coates" },
                new Category { AuthorId = 9, FirstName = "Jared", LastName = "Diamond" },
                new Category { AuthorId = 10, FirstName = "Joan", LastName = "Didion" },
                new Category { AuthorId = 11, FirstName = "Daphne", LastName = "Du Maurier" },
                new Category { AuthorId = 12, FirstName = "Tina", LastName = "Fey" },
                new Category { AuthorId = 13, FirstName = "Roxane", LastName = "Gay" },
                new Category { AuthorId = 14, FirstName = "Dashiel", LastName = "Hammett" },
                new Category { AuthorId = 15, FirstName = "Frank", LastName = "Herbert" },
                new Category { AuthorId = 16, FirstName = "Aldous", LastName = "Huxley" },
                new Category { AuthorId = 17, FirstName = "Stieg", LastName = "Larsson" },
                new Category { AuthorId = 18, FirstName = "David", LastName = "McCullough" },
                new Category { AuthorId = 19, FirstName = "Toni", LastName = "Morrison" },
                new Category { AuthorId = 20, FirstName = "George", LastName = "Orwell" },
                new Category { AuthorId = 21, FirstName = "Mary", LastName = "Shelley" },
                new Category { AuthorId = 22, FirstName = "Sun", LastName = "Tzu" },
                new Category { AuthorId = 23, FirstName = "Augusten", LastName = "Burroughs" },
                new Category { AuthorId = 25, FirstName = "JK", LastName = "Rowling" },
                new Category { AuthorId = 26, FirstName = "Seth", LastName = "Grahame-Smith" }
            );
        }
    }

}