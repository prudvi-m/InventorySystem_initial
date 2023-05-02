using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Models
{
    public class Warehouse
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a warehouse id.")]
        [Remote("CheckWarehouse","Validation",ErrorMessage ="Already exits")]
        public string WarehouseId { get; set; }
        
        [StringLength(25)]
        [Required(ErrorMessage = "Please enter a warehouse name.")]
        [RegularExpression("^[a-zA-Z]+$",ErrorMessage ="Must be alphabets")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a warehouse code.")]
        [RegularExpression("^[0-9]+$",ErrorMessage ="Must be numeric")]
        public int Code { get; set; }

        [StringLength(25)]
        
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter a warehouse name.")]
        [RegularExpression("^[a-zA-Z0-9@]+$",ErrorMessage ="Must be alphabets, numeric and @")]
        [StringLength(25)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a warehouse name.")]
        [RegularExpression("^[0-9]+$",ErrorMessage ="Must be numeric")]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a warehouse name.")]
        [RegularExpression("^[a-zA-Z]+$",ErrorMessage ="Must be alphabets")]
        [StringLength(25)]
        public string ContactPerson { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}