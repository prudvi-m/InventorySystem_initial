using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InventorySystem.Models;

namespace InventorySystem.Areas.Admin.Controllers
{
    
    [Authorize(Roles = "manager")]
    [Area("manager")]
    public class AuthorController : Controller
    {
        private Repository<Category> data { get; set; }
        public AuthorController(InventorySystemContext ctx) => data = new Repository<Category>(ctx);

        public ViewResult Index()
        {
            var authors = data.List(new QueryOptions<Category> {
                OrderBy = a => a.FirstName
            });
            return View(authors);
        }

        public RedirectToActionResult Select(int id, string operation)
        {
            switch (operation.ToLower())
            {
                case "view books":
                    return RedirectToAction("ViewBooks", new { id });
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
        public IActionResult Add(Category author, string operation)
        {
            var validate = new Validate(TempData);
            if (!validate.IsAuthorChecked) {
                validate.CheckAuthor(author.FirstName, author.LastName, operation, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(author.LastName), validate.ErrorMessage);
                }    
            }
            
            if (ModelState.IsValid) {
                data.Insert(author);
                data.Save();
                validate.ClearAuthor();
                TempData["message"] = $"{author.FullName} added to Categories.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Category", author);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => View("Category", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Category author)
        {
            if (ModelState.IsValid) {
                data.Update(author);
                data.Save();
                TempData["message"] = $"{author.FullName} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Category", author);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = data.Get(new QueryOptions<Category> {
                Include = "BookCategories",
                Where = a => a.AuthorId == id
            });

            if (author.BookCategories.Count > 0) {
                TempData["message"] = $"Can't delete author {author.FullName} because they are associated with these books.";
                return GoToAuthorSearch(author);
            }
            else {
                return View("Category", author);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Category author)
        {
            data.Delete(author);
            data.Save();
            TempData["message"] = $"{author.FullName} removed from Categories.";
            return RedirectToAction("Index");  
        }

        public RedirectToActionResult ViewBooks(int id)
        {
            var author = data.Get(id);
            return GoToAuthorSearch(author);
        }

        private RedirectToActionResult GoToAuthorSearch(Category author)
        {
            var search = new SearchData(TempData) {
                SearchTerm = author.FullName,
                Type = "author"
            };
            return RedirectToAction("Search", "Product");
        }
    }
}