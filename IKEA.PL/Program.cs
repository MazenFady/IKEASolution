using IKEA.BLL.Services;
using IKEA.DAL.Context;
using IKEA.DAL.Reporsatories.DepartmentRepo;
using Microsoft.EntityFrameworkCore;

namespace IKEA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });


            builder.Services.AddScoped<IDepartmentReposatry, DepartmentReposatry>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            var app = builder.Build();

      
            app.UseRouting();


            app.UseStaticFiles();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                

            app.Run();
        }
    }
}
