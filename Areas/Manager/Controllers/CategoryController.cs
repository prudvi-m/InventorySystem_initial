using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InventorySystem.Models;

namespace InventorySystem.Areas.Manager.Controllers
{

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class CategoryController : Controller
    {
        private Repository<Category> data { get; set; }
        public CategoryController(InventorySystemContext ctx) => data = new Repository<Category>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var categories = data.List(new QueryOptions<Category> {
                OrderBy = g => g.Name
            });
            return View(categories);
        }

        public RedirectToActionResult Select(int id, string operation)
        {
            switch (operation.ToLower())
            {
                case "view books":
                    return RedirectToAction("ViewProducts", new { id });
                case "edit":
                    return RedirectToAction("Edit", new { id });
                case "delete":
                    return RedirectToAction("Delete", new { id });
                default:
                    return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Add() => View("Category", new Category());

        [HttpPost]
        public IActionResult Add(Category category, string operation)
        {
            var validate = new Validate(TempData);
            if (!validate.IsCategoryChecked) {
                validate.CheckCategory(category.Name, operation, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(category.Name), validate.ErrorMessage);
                }    
            }

            if (ModelState.IsValid) {
                data.Insert(category);
                data.Save();
                validate.ClearCategory();
                TempData["message"] = $"{category.Name} added to Categories.";
                return RedirectToAction("Index");  
            }
            else
                return View("Category", category);
        }

        [HttpGet]
        public ViewResult Edit(int id) => View("Category", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid) {
                data.Update(category);
                data.Save();
                TempData["message"] = $"{category.Name} updated.";
                return RedirectToAction("Index");  
            }
            else
                return View("Category", category);
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var category = data.Get(new QueryOptions<Category> {
                Include = "Categories",
                Where = g => g.CategoryId == id
            });

            if (category.Products.Count > 0) {
                TempData["message"] = $"Can't delete category {category.Name} " 
                                    + "because it's associated with these categories.";
                return GoToCategorySearch(category);
            }
            else {
                return View("Category", category);
            }
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            data.Delete(category);
            data.Save();
            TempData["message"] = $"{category.Name} removed from Categories.";
            return RedirectToAction("Index");  
        }

        private RedirectToActionResult GoToProductSearchResults(string name)
        {
            var search = new SearchData(TempData) {
                SearchTerm = name,
                Type = "category"
            };
            return RedirectToAction("Search", "Product");
        }

        public RedirectToActionResult ViewProducts(string name) => GoToProductSearchResults(name);

        private RedirectToActionResult GoToCategorySearch(Category category)
        {
            var search = new SearchData(TempData) {
                SearchTerm = category.Name,
                Type = "category"
            };
            return RedirectToAction("Search", "Product");
        }
    }
}