using FirstAppNet.Database;
using FirstAppNet.Datastore.SQL.Repository;
using FirstAppNet.Interfaces;
using FirstAppNet.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Services Required by below MapControllerRoute Method
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MarketDBContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("MarketDB"));
    });
//builder.Services.AddSingleton<CategoriesRepository>();
builder.Services.AddTransient<ICategoryRepository,Category_SQL>();
builder.Services.AddTransient<IProductRepository,Product_SQL>();
builder.Services.AddTransient<ITransactionRepository,Transaction_SQL>();

var app = builder.Build();

// Middleware for accessing static files
app.UseStaticFiles();


//Support for MVC
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapGet("/", () => "Hello World!");

app.Run();
