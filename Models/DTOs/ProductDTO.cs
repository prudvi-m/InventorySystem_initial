using System.Collections.Generic;

namespace InventorySystem.Models
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Dictionary<int, string> Categories { get; set; }

        public void Load(Product product)
        {
            ProductId = product.ProductId;
            Title = product.Title;
            Price = product.Price;
            Categories = new Dictionary<int, string>();
            foreach (ProductCategory ba in product.ProductCategories) {
                Categories.Add(ba.Category.CategoryId, ba.Category.FullName);
            }
        }
    }

}
