using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InventorySystem.Models;

namespace InventorySystem.Areas.Admin.Controllers
{
    // [Authorize(Roles = "Manager")]
    [Authorize(Roles = "manager")]
    public class GenreController : Controller
    {
        private Repository<Warehouse> data { get; set; }
        public GenreController(InventorySystemContext ctx) => data = new Repository<Warehouse>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var genres = data.List(new QueryOptions<Warehouse> {
                OrderBy = g => g.Name
            });
            return View(genres);
        }

        [HttpGet]
        public ViewResult Add() => View("Warehouse", new Warehouse());

        [HttpPost]
        public IActionResult Add(Warehouse warehouse)
        {
            var validate = new Validate(TempData);
            if (!validate.IsGenreChecked) {
                validate.CheckGenre(warehouse.GenreId, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(warehouse.GenreId), validate.ErrorMessage);
                }     
            }

            if (ModelState.IsValid) {
                data.Insert(warehouse);
                data.Save();
                validate.ClearGenre();
                TempData["message"] = $"{warehouse.Name} added to Warehouses.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Warehouse", warehouse);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("Warehouse", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Warehouse warehouse)
        {
            if (ModelState.IsValid) {
                data.Update(warehouse);
                data.Save();
                TempData["message"] = $"{warehouse.Name} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Warehouse", warehouse);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id) {
            var warehouse = data.Get(new QueryOptions<Warehouse> {
                Include = "Products",
                Where = g => g.GenreId == id
            });

            if (warehouse.Products.Count > 0) {
                TempData["message"] = $"Can't delete warehouse {warehouse.Name} " 
                                    + "because it's associated with these books.";
                return GoToBookSearchResults(id);
            }
            else {
                return View("Warehouse", warehouse);
            }
        }

        [HttpPost]
        public IActionResult Delete(Warehouse warehouse)
        {
            data.Delete(warehouse);
            data.Save();
            TempData["message"] = $"{warehouse.Name} removed from Warehouses.";
            return RedirectToAction("Index");  
        }

        public RedirectToActionResult ViewBooks(string id) => GoToBookSearchResults(id);

        private RedirectToActionResult GoToBookSearchResults(string id)
        {
            var search = new SearchData(TempData) {
                SearchTerm = id,
                Type = "warehouse"
            };
            return RedirectToAction("Search", "Product");
        }

    }
}