using System;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a Price.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 99999999.99)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a Code.")]
        [Range(1000, 9999, ErrorMessage = "Code must be between 1000 and  9999.")]
        public int? Code { get; set; }
        
        [Required(ErrorMessage = "Please enter a Category.")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter a Warehouse.")]
        public string WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        [Required(ErrorMessage = "Please enter a Vendor.")]
        public string Vendor { get; set; }

        [Required(ErrorMessage = "Please enter a Quantity.")]
        [Range(0, 100, ErrorMessage = "Quantity must be between 0 and 100.")]
        public int? Quantity { get; set; }

    }
}
