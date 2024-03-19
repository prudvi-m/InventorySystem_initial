using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace IP_AmazonFreshIndia_Project.Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		[Required(ErrorMessage = "Please enter a name.")]
		[StringLength(200)]
		public string Name { get; set; }

		public ICollection<ProductCategory> ProductCategories { get; set; }
	}
}
