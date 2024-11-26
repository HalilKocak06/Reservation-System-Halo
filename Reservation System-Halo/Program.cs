using BLL4.DAL;
using BLL4.Services;

//using BLL4.Models;
//using BLL4.Services;
//using BLL4.Services.Bases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//IOC Container:þimdi burada öncelikle connectionString  variable'ý localdbnin yerini oluþturmayý saðlýyor.Ardýndan gelen satýrda Dependency INjection uygulanýyor.Ama tam anlayamadým.
string connectionString = "server=(localdb)\\mssqllocaldb;database=ReservationSystem;trusted_connection=true;";
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IReservationService, ReservationService>();


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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
