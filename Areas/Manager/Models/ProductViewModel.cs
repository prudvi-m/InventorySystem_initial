using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    // public class ProductViewModel : IValidatableObject
    public class ProductViewModel

    {
        public Product Product { get; set; }
        public IEnumerable<Warehouse> Warehouses { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    
    }
}
