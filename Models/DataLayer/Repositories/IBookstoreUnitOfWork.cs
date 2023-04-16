namespace InventorySystem.Models
{
    public interface IInventorySystemUnitOfWork
    {
        Repository<Product> Products { get; }
        Repository<Category> Categories { get; }
        Repository<BookAuthor> BookCategories { get; }
        Repository<Warehouse> Warehouses { get; }

        void DeleteCurrentBookCategories(Product product);
        void LoadNewBookCategories(Product product, int[] authorids);
        void Save();
    }
}
