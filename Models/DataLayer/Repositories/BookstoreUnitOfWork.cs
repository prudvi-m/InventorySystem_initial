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

        private Repository<BookAuthor> bookauthorData;
        public Repository<BookAuthor> BookCategories {
            get {
                if (bookauthorData == null)
                    bookauthorData = new Repository<BookAuthor>(context);
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

        public void DeleteCurrentBookCategories(Product product)
        {
            var currentCategories = BookCategories.List(new QueryOptions<BookAuthor> {
                Where = ba => ba.BookId == product.BookId
            });
            foreach (BookAuthor ba in currentCategories) {
                BookCategories.Delete(ba);
            }
        }

        public void LoadNewBookCategories(Product product, int[] authorids)
        {
            product.BookCategories = authorids.Select(i =>
                new BookAuthor { Product = product, AuthorId = i })
                .ToList();
        }

        public void Save() => context.SaveChanges();
    }
}