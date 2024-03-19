using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IP_AmazonFreshIndia_Project.Models
{
	internal class SeedCategories : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> entity)
		{
			entity.HasData(
				new Category { CategoryId = 1, Name = "Groceries" },
				new Category { CategoryId = 2, Name = "Pharmacy" },
				new Category { CategoryId = 3, Name = "Clothing" },
				new Category { CategoryId = 4, Name = "Electronics" }
			);
		}
	}
}