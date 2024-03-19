using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IP_AmazonFreshIndia_Project.Models
{
	internal class SeedProducts : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> entity)
		{
			entity.HasData(
				new Product { ProductId = 1, Name = "Eggs", WarehouseId = "chicago", Price = 4.29 },
				new Product { ProductId = 2, Name = "Bread", WarehouseId = "newyork", Price = 2.50 },
				new Product { ProductId = 3, Name = "Dish Liquid", WarehouseId = "losangles", Price = 5.50 },
				new Product { ProductId = 4, Name = "Tylenol", WarehouseId = "chicago", Price = 9.50 },
				new Product { ProductId = 5, Name = "Shirt", WarehouseId = "washingtondc", Price = 23.99 },
				new Product { ProductId = 6, Name = "Claritin", WarehouseId = "chicago", Price = 15.19 },
				new Product { ProductId = 7, Name = "Pant", WarehouseId = "chicago", Price = 29.25 },
				new Product { ProductId = 8, Name = "Mobile Phones", WarehouseId = "newyork", Price = 499.99 },
				new Product { ProductId = 9, Name = "Smart Watch", WarehouseId = "chicago", Price = 149.99 },
				new Product { ProductId = 10, Name = "NyQuill", WarehouseId = "chicago", Price = 5.59 }
			);
		}
	}

}
