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

        private Repository<Category> authorData;
        public Repository<Category> Categories {
            get {
                if (authorData == null)
                    authorData = new Repository<Category>(context);
                return authorData;
            }
        }

        private Repository<ProductCategory> bookauthorData;
        public Repository<ProductCategory> ProductCategories {
            get {
                if (bookauthorData == null)
                    bookauthorData = new Repository<ProductCategory>(context);
                return bookauthorData;
            }
        }

        private Repository<Warehouse> genreData;
        public Repository<Warehouse> Warehouses
        {
            get {
                if (genreData == null)
                    genreData = new Repository<Warehouse>(context);
                return genreData;
            }
        }

        public void DeleteCurrentProductCategories(Product product)
        {
            var currentCategories = ProductCategories.List(new QueryOptions<ProductCategory> {
                Where = ba => ba.ProductId == product.ProductId
            });
            foreach (ProductCategory ba in currentCategories) {
                ProductCategories.Delete(ba);
            }
        }

        public void LoadNewProductCategories(Product product, int[] authorids)
        {
            product.ProductCategories = authorids.Select(i =>
                new ProductCategory { Product = product, CategoryId = i })
                .ToList();
        }

        public void Save() => context.SaveChanges();
    }
}