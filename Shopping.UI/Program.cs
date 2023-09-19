using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shopping.BLL.Abstract;
using Shopping.BLL.Concrete;
using Shopping.DAL.Abstract;
using Shopping.DAL.Concrete.EFCore;
using Shopping.DAL.Memory;
using Shopping.UI.Identity;
using Shopping.UI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    //password
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;


    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;

    //user
    options.User.RequireUniqueEmail = true;

    //SignIn
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = true;

});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".FobeShop.Security.Cookie",
        SameSite = SameSiteMode.Strict
    };
});

builder.Services.AddScoped<IProductDal, EfCoreProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

SeedDatabase.Seed();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.CustomStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=index}");
    endpoints.MapControllerRoute(name: "products", pattern: "products/{category?}", defaults: new { controller = "Shop", action = "List" });

    endpoints.MapControllerRoute(name: "adminproducts", pattern: "admin/products", defaults: new { controller = "Admin", action = "ProductList" });

    endpoints.MapControllerRoute(name: "adminproducts", pattern: "admin/products/{id?}", defaults: new { controller = "Admin", action = "EditProduct" });



    endpoints.MapControllerRoute(name: "admincategories", pattern: "admin/categories", defaults: new { controller = "Admin", action = "CategoryList" });

    endpoints.MapControllerRoute(name: "admincategories", pattern: "admin/categories/{id?}", defaults: new { controller = "Admin", action = "EditCategory" });
});

app.Run();
