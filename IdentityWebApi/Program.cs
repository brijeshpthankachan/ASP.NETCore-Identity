using IdentityWebApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder.Services);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

void AddServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

    services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

    services.Configure<IdentityOptions>(opt =>
    {
        opt.Password.RequiredLength = 5;
        opt.Password.RequireLowercase = true;
        opt.Lockout.MaxFailedAccessAttempts = 2;
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    });

    services.AddAuthentication().AddGoogle(options =>
    {
        options.ClientId = "912586231632-7747sd0jqkn9pk9f53r9le613dphacsd.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });
}
