using IronDomeSim.Data;
using IronDomeSim.Data.Services;
using IronDomeSim.Services;
using IronDomeSim.Socket;
using Microsoft.EntityFrameworkCore;

namespace IronDomeSim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<IAPIAttackService, APIAttackService>();
            builder.Services.AddSignalR();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapHub<SocketHub>("hub");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Attacker}/{action=Index}/{id?}");
                //pattern: "{controller=Defenser}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
