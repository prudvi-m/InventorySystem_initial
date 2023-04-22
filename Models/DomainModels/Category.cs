using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public int Code { get; set; }

        [Required("Please enter Name of the category.")]
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

        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
