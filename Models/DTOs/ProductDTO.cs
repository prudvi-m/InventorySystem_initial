using System.Collections.Generic;

namespace IP_AmazonFreshIndia_Project.Models
{
	public class ProductDTO
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public Dictionary<int, string> Categories { get; set; }

		public void Load(Product product)
		{
			ProductId = product.ProductId;
			Name = product.Name;
			Price = product.Price;
			Categories = new Dictionary<int, string>();
			foreach (ProductCategory ba in product.ProductCategories)
			{
				Categories.Add(ba.Category.CategoryId, ba.Category.Name);
			}
		}
	}

}
