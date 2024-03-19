using Newtonsoft.Json;

namespace IP_AmazonFreshIndia_Project.Models
{
	public class CartItem
	{
		public ProductDTO Product { get; set; }
		public int Quantity { get; set; }

		[JsonIgnore]
		public double Subtotal => Product.Price * Quantity;
	}
}
