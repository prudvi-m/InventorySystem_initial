using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Models
{
    internal class SeedProductCategories : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> entity)
        {
            entity.HasData(
                new ProductCategory { ProductId = 1, CategoryId = 18 },
                new ProductCategory { ProductId = 2, CategoryId = 20 },
                new ProductCategory { ProductId = 3, CategoryId = 7 },
                new ProductCategory { ProductId = 4, CategoryId = 2 },
                new ProductCategory { ProductId = 5, CategoryId = 19 },
                new ProductCategory { ProductId = 6, CategoryId = 8 },
                new ProductCategory { ProductId = 7, CategoryId = 12 },
                new ProductCategory { ProductId = 8, CategoryId = 16 },
                new ProductCategory { ProductId = 9, CategoryId = 2 },
                new ProductCategory { ProductId = 10, CategoryId = 20 },
                new ProductCategory { ProductId = 11, CategoryId = 15 },
                new ProductCategory { ProductId = 12, CategoryId = 4 },
                new ProductCategory { ProductId = 13, CategoryId = 21 },
                new ProductCategory { ProductId = 14, CategoryId = 5 },
                new ProductCategory { ProductId = 15, CategoryId = 9 },
                new ProductCategory { ProductId = 16, CategoryId = 13 },
                new ProductCategory { ProductId = 17, CategoryId = 7 },
                new ProductCategory { ProductId = 18, CategoryId = 4 },
                new ProductCategory { ProductId = 19, CategoryId = 11 },
                new ProductCategory { ProductId = 20, CategoryId = 22 },
                new ProductCategory { ProductId = 21, CategoryId = 17 },
                new ProductCategory { ProductId = 22, CategoryId = 3 },
                new ProductCategory { ProductId = 23, CategoryId = 14 },
                new ProductCategory { ProductId = 24, CategoryId = 1 },
                new ProductCategory { ProductId = 25, CategoryId = 10 },
                new ProductCategory { ProductId = 26, CategoryId = 6 },
                new ProductCategory { ProductId = 27, CategoryId = 23 },
                new ProductCategory { ProductId = 28, CategoryId = 4 },
                new ProductCategory { ProductId = 28, CategoryId = 26 },
                new ProductCategory { ProductId = 29, CategoryId = 25 }
            );
        }
    }

}
