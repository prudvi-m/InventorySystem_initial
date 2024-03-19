using System.Collections.Generic;

namespace IP_AmazonFreshIndia_Project.Models
{
	public class CartViewModel
	{
		public IEnumerable<CartItem> List { get; set; }
		public double Subtotal { get; set; }
		public RouteDictionary ProductGridRoute { get; set; }
	}
}
