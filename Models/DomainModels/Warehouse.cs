using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace IP_AmazonFreshIndia_Project.Models
{
	public class Warehouse
	{
		[MaxLength(10)]
		[Required(ErrorMessage = "Please enter a warehouse id.")]
		[Remote("CheckWarehouse", "Validation", "Area")]
		public string WarehouseId { get; set; }

		[StringLength(25)]
		[Required(ErrorMessage = "Please enter a warehouse name.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter a warehouse code.")]
		public int Code { get; set; }

		[StringLength(25)]
		public string Location { get; set; }

		[StringLength(25)]
		public string Email { get; set; }

		[StringLength(25)]
		public string Phone { get; set; }

		[StringLength(25)]
		public string ContactPerson { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}