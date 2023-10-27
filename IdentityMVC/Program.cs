using IdentityMVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder.Services);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();



void AddServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddDbContext<ApplicationDbContext>(dbConextOptions =>
        dbConextOptions.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
}
