using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IP_AmazonFreshIndia_Project.Models;

namespace IP_AmazonFreshIndia_Project.Areas.Admin.Controllers
{

	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private Repository<Category> data { get; set; }
		public CategoryController(IP_AmazonFreshIndia_ProjectContext ctx) => data = new Repository<Category>(ctx);

		public ViewResult Index()
		{
			var categories = data.List(new QueryOptions<Category>
			{
				OrderBy = a => a.Name
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
			if (!validate.IsCategoryChecked)
			{
				validate.CheckCategory(category.Name, operation, data);
				if (!validate.IsValid)
				{
					ModelState.AddModelError(nameof(category.Name), validate.ErrorMessage);
				}
			}

			if (ModelState.IsValid)
			{
				data.Insert(category);
				data.Save();
				validate.ClearCategory();
				TempData["message"] = $"{category.Name} added to Categories.";
				return RedirectToAction("Index");
			}
			else
			{
				return View("Category", category);
			}
		}

		[HttpGet]
		public ViewResult Edit(int id) => View("Category", data.Get(id));

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				data.Update(category);
				data.Save();
				TempData["message"] = $"{category.Name} updated.";
				return RedirectToAction("Index");
			}
			else
			{
				return View("Category", category);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var category = data.Get(new QueryOptions<Category>
			{
				Include = "ProductCategories",
				Where = a => a.CategoryId == id
			});

			if (category.ProductCategories.Count > 0)
			{
				TempData["message"] = $"Can't delete category {category.Name} because they are associated with these books.";
				return GoToCategorySearch(category);
			}
			else
			{
				return View("Category", category);
			}
		}

		[HttpPost]
		public RedirectToActionResult Delete(Category category)
		{
			data.Delete(category);
			data.Save();
			TempData["message"] = $"{category.Name} removed from Categories.";
			return RedirectToAction("Index");
		}

		public RedirectToActionResult ViewProducts(int id)
		{
			var category = data.Get(id);
			return GoToCategorySearch(category);
		}

		private RedirectToActionResult GoToCategorySearch(Category category)
		{
			var search = new SearchData(TempData)
			{
				SearchTerm = category.Name,
				Type = "category"
			};
			return RedirectToAction("Search", "Product");
		}
	}
}