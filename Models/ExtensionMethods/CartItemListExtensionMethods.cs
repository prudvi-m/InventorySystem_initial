using System.Linq;
using System.Collections.Generic;

namespace IP_AmazonFreshIndia_Project.Models
{
	public static class CartItemListExtensions
	{
		public static List<CartItemDTO> ToDTO(this List<CartItem> list) =>
			list.Select(ci => new CartItemDTO
			{
				ProductId = ci.Product.ProductId,
				Quantity = ci.Quantity
			}).ToList();
	}
}
