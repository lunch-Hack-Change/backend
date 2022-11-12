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

            var con = "Data Source=HackAndChange.db";

            builder.Services.AddDbContext<HackAndChangeContext>(options => options.UseSqlite(con));
            builder.Services.AddControllers();

            var app = builder.Build();

            //app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.Run();
        }
    }
}