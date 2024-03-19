using Microsoft.AspNetCore.Mvc;
using IP_AmazonFreshIndia_Project.Models;

namespace IP_AmazonFreshIndia_Project.Controllers
{
	public class CategoryController : Controller
	{
		private Repository<Category> data { get; set; }
		public CategoryController(IP_AmazonFreshIndia_ProjectContext ctx) => data = new Repository<Category>(ctx);

		public IActionResult Index() => RedirectToAction("List");

		// [HttpGet]
		public ViewResult List(GridDTO vals)
		{
			string defaultSort = nameof(Category.Name);
			var builder = new GridBuilder(HttpContext.Session, vals, defaultSort);
			builder.SaveRouteSegments();

			var options = new QueryOptions<Category>
			{
				Include = "ProductCategories.Product",
				PageNumber = builder.CurrentRoute.PageNumber,
				PageSize = builder.CurrentRoute.PageSize,
				OrderByDirection = builder.CurrentRoute.SortDirection
			};
			if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
				options.OrderBy = a => a.Name;
			else
				options.OrderBy = a => a.Name;

			var vm = new CategoryListViewModel
			{
				Categories = data.List(options),
				CurrentRoute = builder.CurrentRoute,
				TotalPages = builder.GetTotalPages(data.Count)
			};

			return View(vm);
		}

		public IActionResult Details(int id)
		{
			var category = data.Get(new QueryOptions<Category>
			{
				Include = "ProductCategories.Product",
				Where = a => a.CategoryId == id
			});
			return View(category);
		}
	}
}