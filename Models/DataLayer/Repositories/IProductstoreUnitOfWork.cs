namespace InventorySystem.Models
{
    public interface IInventorySystemUnitOfWork
    {
        Repository<Product> Products { get; }
        Repository<Category> Categories { get; }
        Repository<Warehouse> Warehouses { get; }
        void Save();
    }
}
