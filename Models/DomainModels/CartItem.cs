using Newtonsoft.Json;

namespace InventorySystem.Models
{
    public class CartItem
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => Product.Price * Quantity;
    }
}
