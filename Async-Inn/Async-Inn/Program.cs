using Async_Inn.Data;
using Async_Inn.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Async_Inn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. 
            builder.Services.AddControllersWithViews();

            /* TODO
            builder.Services.addContext
             */

            builder.Services.AddDbContext<AsyncInnContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                    .GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IHotel, HotelService>();

            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");

            app.UseAuthorization();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controler=Home}/{action=Index}/{id?}");

            // https://localhost:44391/Home/Hotel/CheckIn/1


            app.Run();
        }
    }
}
