using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;

namespace Vigus.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var conStr = builder.Configuration.GetConnectionString("DefaultCon");

        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<VigusGpuContext>(options => options.UseLazyLoadingProxies().UseSqlServer(conStr));

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

        app.MapControllerRoute(
            "default",
            "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}