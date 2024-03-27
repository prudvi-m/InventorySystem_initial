using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IP_AmazonFreshIndia_Project.Models;

namespace IP_AmazonFreshIndia_Project.Areas.Admin.Controllers
{

	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	public class WarehouseController : Controller
	{
		private Repository<Warehouse> data { get; set; }
		public WarehouseController(IP_AmazonFreshIndia_ProjectContext ctx) => data = new Repository<Warehouse>(ctx);

		private IP_AmazonFreshIndia_ProjectContext con;

		public ViewResult Index()
		{
			var search = new SearchData(TempData);
			search.Clear();

			var warehouses = data.List(new QueryOptions<Warehouse>
			{
				OrderBy = g => g.Name
			});
			return View(warehouses);
		}

		[HttpGet]
		public ViewResult Add() => View("Warehouse", new Warehouse());

		[HttpPost]
		public IActionResult Add(Warehouse warehouse)
		{
			var validate = new Validate(TempData);
			if (!validate.IsWarehouseChecked)
			{
				validate.CheckWarehouse(warehouse.WarehouseId, data);
				if (!validate.IsValid)
				{
					ModelState.AddModelError(nameof(warehouse.WarehouseId), validate.ErrorMessage);
				}
			}

			if (ModelState.IsValid)
			{
				data.Insert(warehouse);
				data.Save();
				validate.ClearWarehouse();
				TempData["message"] = $"{warehouse.Name} added to Warehouses.";
				return RedirectToAction("Index");
			}
			else
			{
				return View("Warehouse", warehouse);
			}
		}

		[HttpGet]
		public ViewResult Edit(string id) => View("Warehouse", data.Get(id));

		[HttpPost]
		public IActionResult Edit(Warehouse warehouse)
		{
			if (ModelState.IsValid)
			{
				data.Update(warehouse);
				data.Save();
				TempData["message"] = $"{warehouse.Name} updated.";
				return RedirectToAction("Index");
			}
			else
			{
				return View("Warehouse", warehouse);
			}
		}

		[HttpGet]
		public IActionResult Delete(string id)
		{
			var warehouse = data.Get(new QueryOptions<Warehouse>
			{
				Include = "Products",
				Where = g => g.WarehouseId == id
			});

			if (warehouse.Products.Count > 0)
			{
				TempData["message"] = $"Can't delete warehouse {warehouse.Name} "
									+ "because it's associated with these books.";
				return GoToProductSearchResults(id);
			}
			else
			{
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

		public RedirectToActionResult ViewProducts(string id) => GoToProductSearchResults(id);

		private RedirectToActionResult GoToProductSearchResults(string id)
		{
			var search = new SearchData(TempData)
			{
				SearchTerm = id,
				Type = "warehouse"
			};
			return RedirectToAction("Search", "Product");
		}

	}
}