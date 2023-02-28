
using DigitalLibraryApplication.Middleware;
using DigitalLibraryApplication.MiddlewareExtensions;
using DigitalLibraryApplication.Models;
using DigitalLibraryApplication.Services;
using Microsoft.EntityFrameworkCore;

public IConfiguration Configuration { get; }
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<EmailService>();
var connection = Configuration.GetConnectionString("Default");
if(connection == null)
{
    connection = "testingconnection";
}
builder.Services.AddDbContext<DigitalLibraryContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseMiddleware<SimpleMiddleware>();

app.UseSimpleMiddleware();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public partial class Program { }