using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IP_AmazonFreshIndia_Project.Models;
using System.Linq;
using System.Collections.Generic;

namespace IP_AmazonFreshIndia_Project
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRouting(options => options.LowercaseUrls = true);

			services.AddMemoryCache();
			services.AddSession();

			services.AddControllersWithViews().AddNewtonsoftJson();

			services.AddDbContext<IP_AmazonFreshIndia_ProjectContext>(options =>
				options.UseSqlite(Configuration.GetConnectionString("IP_AmazonFreshIndia_ProjectContext")));

			// add this
			services.AddIdentity<User, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 4;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
			}).AddEntityFrameworkStores<IP_AmazonFreshIndia_ProjectContext>()
			  .AddDefaultTokenProviders();
		}

		// Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app)
		{
			app.UseDeveloperExceptionPage();
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();   // add this
			app.UseAuthorization();    // add this

			app.UseSession();

			app.UseEndpoints(endpoints =>
			{
				// route for Manager area
				endpoints.MapAreaControllerRoute(
					name: "manager",
					areaName: "Manager",
					pattern: "Manager/{controller=Product}/{action=Index}/{id?}");

				// route for paging, sorting, and filtering
				endpoints.MapControllerRoute(
					name: "",
					pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}/filter/{category}/{warehouse}/{price}");

				// route for paging and sorting only
				endpoints.MapControllerRoute(
					name: "",
					pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}");

				// default route
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
			});

			IP_AmazonFreshIndia_ProjectContext.CreateAdminUser(app.ApplicationServices).Wait();
		}
	}
}