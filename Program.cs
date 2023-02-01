using store1.Data;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString));
var app = builder.Build();

//builder.Configuration.GetConnectionString("Data Source=DESKTOP-2E84EKK;Initial Catalog =store;Integrated Security=True;Connect Timeout=30;" +
//"Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite" +
//";MultiSubnetFailover=False;"

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
app.MapControllerRoute(
    name: "Customer",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
