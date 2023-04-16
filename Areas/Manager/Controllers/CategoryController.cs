﻿using Microsoft.AspNetCore.Mvc;
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
            var categories = data.List(new QueryOptions<Category> {
                OrderBy = a => a.FirstName
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
            if (!validate.IsAuthorChecked) {
                validate.CheckAuthor(category.FirstName, category.LastName, operation, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(category.LastName), validate.ErrorMessage);
                }    
            }
            
            if (ModelState.IsValid) {
                data.Insert(category);
                data.Save();
                validate.ClearAuthor();
                TempData["message"] = $"{category.FullName} added to Categories.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Category", category);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => View("Category", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid) {
                data.Update(category);
                data.Save();
                TempData["message"] = $"{category.FullName} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Category", category);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = data.Get(new QueryOptions<Category> {
                Include = "ProductCategories",
                Where = a => a.CategoryId == id
            });

            if (category.ProductCategories.Count > 0) {
                TempData["message"] = $"Can't delete category {category.FullName} because they are associated with these books.";
                return GoToAuthorSearch(category);
            }
            else {
                return View("Category", category);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Category category)
        {
            data.Delete(category);
            data.Save();
            TempData["message"] = $"{category.FullName} removed from Categories.";
            return RedirectToAction("Index");  
        }

        public RedirectToActionResult ViewProducts(int id)
        {
            var category = data.Get(id);
            return GoToAuthorSearch(category);
        }

        private RedirectToActionResult GoToAuthorSearch(Category category)
        {
            var search = new SearchData(TempData) {
                SearchTerm = category.FullName,
                Type = "category"
            };
            return RedirectToAction("Search", "Product");
        }
    }
}