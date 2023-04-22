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

        public int Code { get; set; }

        [Required(ErrorMessage = "Please enter Name of the category.")]
        [StringLength(200)]
        public string Name { get; set; }
        
        [StringLength(200)]
        public string Location { get; set; }
        
        [StringLength(200)]
        public string Email { get; set; }
        
        [StringLength(200)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string ContactPerson { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}