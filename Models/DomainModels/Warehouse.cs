using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Models
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

        public ICollection<Product> Products { get; set; }
    }
}