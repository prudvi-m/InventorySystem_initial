using System.Collections.Generic;

namespace IP_AmazonFreshIndia_Project.Models
{
	public class CategoryListViewModel
	{
		public IEnumerable<Category> Categories { get; set; }
		public RouteDictionary CurrentRoute { get; set; }
		public int TotalPages { get; set; }
	}
}
