using System.Collections.Generic;

namespace InventorySystem.Models
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Dictionary<int, string> Categories { get; set; }

        public void Load(Product product)
        {
            BookId = product.BookId;
            Title = product.Title;
            Price = product.Price;
            Categories = new Dictionary<int, string>();
            foreach (BookAuthor ba in product.BookCategories) {
                Categories.Add(ba.Category.AuthorId, ba.Category.FullName);
            }
        }
    }

}
