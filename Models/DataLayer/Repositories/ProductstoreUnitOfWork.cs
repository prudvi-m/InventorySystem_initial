using System.Linq;

namespace IP_AmazonFreshIndia_Project.Models
{
	public class IP_AmazonFreshIndia_ProjectUnitOfWork : IIP_AmazonFreshIndia_ProjectUnitOfWork
	{
		private IP_AmazonFreshIndia_ProjectContext context { get; set; }
		public IP_AmazonFreshIndia_ProjectUnitOfWork(IP_AmazonFreshIndia_ProjectContext ctx) => context = ctx;

		private Repository<Product> bookData;
		public Repository<Product> Products
		{
			get
			{
				if (bookData == null)
					bookData = new Repository<Product>(context);
				return bookData;
			}
		}

		private Repository<Category> categoryData;
		public Repository<Category> Categories
		{
			get
			{
				if (categoryData == null)
					categoryData = new Repository<Category>(context);
				return categoryData;
			}
		}

		private Repository<ProductCategory> bookcategoryData;
		public Repository<ProductCategory> ProductCategories
		{
			get
			{
				if (bookcategoryData == null)
					bookcategoryData = new Repository<ProductCategory>(context);
				return bookcategoryData;
			}
		}

		private Repository<Warehouse> warehouseData;
		public Repository<Warehouse> Warehouses
		{
			get
			{
				if (warehouseData == null)
					warehouseData = new Repository<Warehouse>(context);
				return warehouseData;
			}
		}

		public void DeleteCurrentProductCategories(Product product)
		{
			var currentCategories = ProductCategories.List(new QueryOptions<ProductCategory>
			{
				Where = ba => ba.ProductId == product.ProductId
			});
			foreach (ProductCategory ba in currentCategories)
			{
				ProductCategories.Delete(ba);
			}
		}

		public void LoadNewProductCategories(Product product, int[] categoryids)
		{
			product.ProductCategories = categoryids.Select(i =>
				new ProductCategory { Product = product, CategoryId = i })
				.ToList();
		}

		public void Save() => context.SaveChanges();
	}
}