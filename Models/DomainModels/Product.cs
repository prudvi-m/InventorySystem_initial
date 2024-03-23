using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IP_AmazonFreshIndia_Project.Models
{
	public partial class Product
	{
		public int ProductId { get; set; }

		[Required(ErrorMessage = "Please enter the product name.")]
		public string Name { get; set; }

		public string Description { get; set; }

		[Required(ErrorMessage = "Please enter a Price.")]
		[Range(0.0, 1000000.0, ErrorMessage = "Price must be more than 0.")]
		public double Price { get; set; }


		[Range(1000, 9999, ErrorMessage = "Code must be between 1000 and  9999.")]
		public int? Code { get; set; }

		public string WarehouseId { get; set; }
		public Warehouse Warehouse { get; set; }

		public ICollection<ProductCategory> ProductCategories { get; set; }


		public string Vendor { get; set; }


		[Range(0, 100, ErrorMessage = "Quantity must be between 0 and 100.")]
		public int? Quantity { get; set; }

		public string ProductImage { get; set; }


	}
}
