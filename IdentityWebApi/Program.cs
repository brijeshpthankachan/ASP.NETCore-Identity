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
}
