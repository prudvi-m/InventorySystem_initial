using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IP_AmazonFreshIndia_Project.Models
{
	internal class SeedProductCategories : IEntityTypeConfiguration<ProductCategory>
	{
		public void Configure(EntityTypeBuilder<ProductCategory> entity)
		{
			entity.HasData(
				new ProductCategory { ProductId = 1, CategoryId = 1 },
				new ProductCategory { ProductId = 2, CategoryId = 1 },
				new ProductCategory { ProductId = 3, CategoryId = 1 },
				new ProductCategory { ProductId = 4, CategoryId = 2 },
				new ProductCategory { ProductId = 5, CategoryId = 3 },
				new ProductCategory { ProductId = 6, CategoryId = 2 },
				new ProductCategory { ProductId = 7, CategoryId = 3 },
				new ProductCategory { ProductId = 8, CategoryId = 4 },
				new ProductCategory { ProductId = 9, CategoryId = 4 },
				new ProductCategory { ProductId = 10, CategoryId = 2 }

			);
		}
	}

}
