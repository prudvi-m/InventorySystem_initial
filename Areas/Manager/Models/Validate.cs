using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace InventorySystem.Models
{
    public class Validate
    {
        private const string WarehouseKey = "validWarehouse";
        private const string AuthorKey = "validAuthor";
        private const string EmailKey = "validEmail";

        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        public void CheckWarehouse(string warehouseId, Repository<Warehouse> data)
        {
            Warehouse entity = data.Get(warehouseId);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : 
                $"Warehouse id {warehouseId} is already in the database.";
        }
        public void MarkWarehouseChecked() => tempData[WarehouseKey] = true;
        public void ClearWarehouse() => tempData.Remove(WarehouseKey);
        public bool IsWarehouseChecked => tempData.Keys.Contains(WarehouseKey);

        public void CheckAuthor(string firstName, string lastName, string operation, Repository<Category> data)
        {
            Category entity = null; 
            if (Operation.IsAdd(operation)) {
                entity = data.Get(new QueryOptions<Category> {
                    Where = a => a.Name == firstName && a.Name == lastName });
            }
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : 
                $"Category {entity.Name} is already in the database.";
        }
        public void MarkAuthorChecked() => tempData[AuthorKey] = true;
        public void ClearAuthor() => tempData.Remove(AuthorKey);
        public bool IsAuthorChecked => tempData.Keys.Contains(AuthorKey);
    }
}
