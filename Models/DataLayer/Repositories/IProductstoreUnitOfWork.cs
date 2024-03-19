namespace IP_AmazonFreshIndia_Project.Models
{
	public interface IIP_AmazonFreshIndia_ProjectUnitOfWork
	{
		Repository<Product> Products { get; }
		Repository<Category> Categories { get; }
		Repository<ProductCategory> ProductCategories { get; }
		Repository<Warehouse> Warehouses { get; }

		void DeleteCurrentProductCategories(Product product);
		void LoadNewProductCategories(Product product, int[] categoryids);
		void Save();
	}
}
