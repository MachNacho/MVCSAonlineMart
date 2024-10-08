using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SAonlineMart.Data;
using SAonlineMart.Interfaces;
using SAonlineMart.Models;
using SAonlineMart.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductRepository, ProductRepository>();//added repository service
builder.Services.AddScoped<ICartRepository, CartRepository>();//added repository service
builder.Services.AddScoped<IOrderRepository, OrderRepository>();//added repository service
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBcontext>(Options => { Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });//add service to auto connect to db view address
builder.Services.AddIdentity<Customer,IdentityRole>().AddEntityFrameworkStores<ApplicationDBcontext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
var app = builder.Build();
if (args.Length == 1 && args[0].ToLower() == "seeddata")// allows for test data to be loaded with command
{
    await Seed.SeedUsersAndRolesAsync(app);
}
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
