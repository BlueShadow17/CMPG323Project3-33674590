using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data;
using EcoPower_Logistics.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure the DbContext to use SQL Server with the specified connection string.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register repository services for dependency injection.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Enable developer-friendly database error pages.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure a separate DbContext called SuperStoreContext. This is missing the connection string.
builder.Services.AddDbContext<SuperStoreContext>();

// Configure Identity with default options, like user sign-in requirements.
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Configure MVC controllers with views.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
// If the application is in development mode, use the migrations endpoint for database management.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // Use a custom error page for exceptions in non-development environments.
    app.UseExceptionHandler("/Home/Error");

    // Optionally, enable HTTP Strict Transport Security (HSTS) for added security.
    // app.UseHsts();
}

// Enable HTTPS redirection (commented out in this code).
// app.UseHttpsRedirection();

// Serve static files (e.g., CSS, JavaScript, images) from wwwroot.
app.UseStaticFiles();

// Enable routing for URL-based navigation.
app.UseRouting();

// Enable authentication to identify users.
app.UseAuthentication();

// Enable authorization to control access to resources.
app.UseAuthorization();

// Map the default controller route and Razor Pages.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Start the application.
app.Run();
