using System.Linq;

namespace InventorySystem.Models
{
    public class InventorySystemUnitOfWork : IInventorySystemUnitOfWork
    {
        private InventorySystemContext context { get; set; }
        public InventorySystemUnitOfWork(InventorySystemContext ctx) => context = ctx;

        private Repository<Product> bookData;
        public Repository<Product> Products {
            get {
                if (bookData == null)
                    bookData = new Repository<Product>(context);
                return bookData;
            }
        }

        private Repository<Category> categoryData;
        public Repository<Category> Categories {
            get {
                if (categoryData == null)
                    categoryData = new Repository<Category>(context);
                return categoryData;
            }
        }

        

        private Repository<Warehouse> warehouseData;
        public Repository<Warehouse> Warehouses
        {
            get {
                if (warehouseData == null)
                    warehouseData = new Repository<Warehouse>(context);
                return warehouseData;
            }
        }
        
        public void Save() => context.SaveChanges();
    }
}