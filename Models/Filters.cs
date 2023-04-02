using System.Collections.Generic;

namespace InventorySystem.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            CategoryId = filters[0];
            WarehouseId = filters[1];
        }
        public string FilterString { get; }
        public string CategoryId { get; }
        public string WarehouseId { get; }

        public bool HasCategory => CategoryId.ToLower() != "all";
        public bool HasWarehouse => WarehouseId.ToLower() != "all";
    }
}
