using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace IP_AmazonFreshIndia_Project.Models
{
    public class IP_AmazonFreshIndia_ProjectContext : IdentityDbContext<User>
    {
        public IP_AmazonFreshIndia_ProjectContext(DbContextOptions<IP_AmazonFreshIndia_ProjectContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ProductCategory>().HasKey(ba => new { ba.ProductId, ba.CategoryId });


            modelBuilder.Entity<ProductCategory>().HasOne(ba => ba.Product)
                .WithMany(b => b.ProductCategories)
                .HasForeignKey(ba => ba.ProductId);
            modelBuilder.Entity<ProductCategory>().HasOne(ba => ba.Category)
                .WithMany(a => a.ProductCategories)
                .HasForeignKey(ba => ba.CategoryId);


            modelBuilder.Entity<Product>().HasOne(b => b.Warehouse)
                .WithMany(g => g.Products)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.ApplyConfiguration(new SeedWarehouses());
            modelBuilder.ApplyConfiguration(new SeedProducts());
            modelBuilder.ApplyConfiguration(new SeedCategories());
            modelBuilder.ApplyConfiguration(new SeedProductCategories());
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userAdmin =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleAdmin =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            var userCreationList = new List<UserCreation>{
                new UserCreation() {
                    username = "admin",
                    password = "Testing",
                    roleName = "Admin"
                },
                new UserCreation() {
                    username = "vamshi",
                    password = "Testing",
                    roleName = "User"
                },
            };

            foreach (var userCreation in userCreationList)
            {

                if (await roleAdmin.FindByNameAsync(userCreation.roleName) == null)
                    await roleAdmin.CreateAsync(new IdentityRole(userCreation.roleName));


                if (await userAdmin.FindByNameAsync(userCreation.username) == null)
                {
                    User user = new User { UserName = userCreation.username };
                    var result = await userAdmin.CreateAsync(user, userCreation.password);
                    if (result.Succeeded)
                        await userAdmin.AddToRoleAsync(user, userCreation.roleName);
                }
            }
        }
    }

    public class UserCreation
    {

        public string username = "";
        public string password = "";
        public string roleName = "";
    }
}