using System.Collections.Generic;

namespace InventorySystem.Models
{
    public class AuthorListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
