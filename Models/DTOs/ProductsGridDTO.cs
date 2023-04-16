using Newtonsoft.Json;

namespace InventorySystem.Models
{
    public class ProductsGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Category { get; set; } = DefaultFilter;
        public string Warehouse { get; set; } = DefaultFilter;
        public string Price { get; set; } = DefaultFilter;
    }
}
