using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;

namespace InventorySystem.Areas.Admin.Controllers
{
    // [Area("Manager")]
    [Area("manager")]
    public class ValidationController : Controller
    {
        private Repository<Category> authorData { get; set; }
        private Repository<Warehouse> genreData { get; set; }

        public ValidationController(InventorySystemContext ctx)
        { 
            authorData = new Repository<Category>(ctx);
            genreData = new Repository<Warehouse>(ctx);
        }

        public JsonResult CheckGenre(string genreId)
        {
            var validate = new Validate(TempData);
            validate.CheckGenre(genreId, genreData);
            if (validate.IsValid) {
                validate.MarkGenreChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckAuthor(string firstName, string lastName, string operation)
        {
            var validate = new Validate(TempData);
            validate.CheckAuthor(firstName, lastName, operation, authorData);
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