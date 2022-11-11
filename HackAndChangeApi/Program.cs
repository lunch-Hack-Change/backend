using HackAndChangeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HackAndChangeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var con = "Server=(localdb)\\mssqllocaldb;Database=HackAndChange;Trusted_Connection=True;";

            builder.Services.AddDbContext<HackAndChangeContext>(options => options.UseSqlServer(con));
            builder.Services.AddControllers();

            var app = builder.Build();

            //app.UseHttpsRedirection();

            //app.UseAuthorization();
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.Run();
        }
    }
}