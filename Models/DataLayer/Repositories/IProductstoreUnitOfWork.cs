namespace InventorySystem.Models
{
    public interface IInventorySystemUnitOfWork
    {
        Repository<Product> Products { get; }
        Repository<Category> Categories { get; }
        Repository<ProductCategory> ProductCategories { get; }
        Repository<Warehouse> Warehouses { get; }

        void DeleteCurrentProductCategories(Product product);
        void LoadNewProductCategories(Product product, int[] authorids);
        void Save();
    }
}
