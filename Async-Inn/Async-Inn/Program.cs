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
            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler
                = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            /* TODO
            builder.Services.addContext
             */
            builder.Services.AddDbContext<AsyncInnContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                    .GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //https://localhost:5152/Hotel/CheckIn/
            //https://website/Hotel/CheckOut
            //https://website/Hotel/
            // http://localhost:5152
            // https://localhost:7252

            /*
             * 
             * 
            
             */

            app.Run();
        }
    }
}
