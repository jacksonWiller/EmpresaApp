// using EmpresaApp.Data;
// using Microsoft.EntityFrameworkCore;

using EmpresaApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EmpresaApp;

public class Startup{

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigurationService(IServiceCollection services)
    {
        services.AddControllersWithViews();
       
       services.AddDbContext<DataContext>(
                //context => context.UseSqlite(Configuration.GetConnectionString("Default"))
                context => context.UseSqlServer(Configuration.GetConnectionString("DevConnection"))
            );
       services.AddRazorPages();

    }

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Empresa}/{action=Index}/{id?}");

        app.Run();
    }
}

