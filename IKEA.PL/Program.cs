using IKEA.BLL.Mapping.MappingProfile;
using IKEA.BLL.Services.DepartmentService;
using IKEA.BLL.Services.DepartmentServices;
using IKEA.BLL.Services.DepartmentServices.DepartmentService;
using IKEA.BLL.Services.EmployeeServices;
using IKEA.DAL.Context;
using IKEA.DAL.Reporsatories.DepartmentRepo;
using IKEA.DAL.Reporsatories.EmployeeRepo;
using Microsoft.Build.Evaluation;
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


            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddAutoMapper(m=>m.AddProfile(new ProjectMapperProfile()));

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
