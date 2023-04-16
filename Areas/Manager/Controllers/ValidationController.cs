using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;

namespace InventorySystem.Areas.Manager.Controllers
{
    // [Area("Manager")]
    [Area("manager")]
    public class ValidationController : Controller
    {
        private Repository<Category> categoryData { get; set; }
        private Repository<Warehouse> warehouseData { get; set; }

        public ValidationController(InventorySystemContext ctx)
        { 
            categoryData = new Repository<Category>(ctx);
            warehouseData = new Repository<Warehouse>(ctx);
        }

        public JsonResult CheckWarehouse(string warehouseId)
        {
            var validate = new Validate(TempData);
            validate.CheckWarehouse(warehouseId, warehouseData);
            if (validate.IsValid) {
                validate.MarkWarehouseChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckAuthor(string firstName, string lastName, string operation)
        {
            var validate = new Validate(TempData);
            validate.CheckAuthor(firstName, lastName, operation, categoryData);
            if (validate.IsValid) {
                validate.MarkAuthorChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }
    }
}