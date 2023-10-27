using IdentityMVC.Data;
using IdentityMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder.Services);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

void AddServices(IServiceCollection services)
{
    // This method configures the MVC services for the commonly used features with controllers and views.
    // Note that this method does not register services used for pages.
    services.AddControllersWithViews();

    // Registers the given context as a service.
    services.AddDbContext<ApplicationDbContext>(dbConextOptions =>
        dbConextOptions.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

    // Adds The Default Identity configurations for the specified user and role.
    services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

    // Configuring IdentityOptions for Authentication and Password Policy Settings
    // Defines and register an action that configures the IdentityOptions.
    // https://stackoverflow.com/questions/53424593/services-configure-or-services-addsingleton-get
    services.Configure<IdentityOptions>(opt =>
    {
        opt.Password.RequiredLength = 5;
        opt.Password.RequireLowercase = true;
        opt.Lockout.MaxFailedAccessAttempts = 2;
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
        opt.SignIn.RequireConfirmedEmail = false;
    });

    services.AddScoped<IEmailSender, EmailSender>();
}
