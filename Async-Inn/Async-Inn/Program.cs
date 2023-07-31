using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. 
            builder.Services.AddControllersWithViews();

            // todo
            // builder.Services.addContext

            builder.Services.AddDbContext<AsyncInnContext>(options =>
            options.UseSqlServer(
                builder.Configuration
                .GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");

            app.UseHttpsRedirection(); // middleware
            app.UseStaticFiles(); // middleware
            app.UseRouting(); // middleware
            app.UseAuthentication(); // middleware

            app.MapControllerRoute(
                name: "default",
                pattern: "{controler=Home}/{action=Index}/{id?}");

            // https://localhost:44391/Home/Hotel/CheckIn/1


            app.Run();
        }
    }
}