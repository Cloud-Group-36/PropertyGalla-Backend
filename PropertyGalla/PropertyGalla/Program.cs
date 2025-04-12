using Microsoft.EntityFrameworkCore;
using PropertyGalla.Data;
using PropertyGalla.Services; // ✅ Include the service namespace

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Register the database context with connection string from appsettings.json
builder.Services.AddDbContext<PropertyGallaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register the IdGeneratorService for dependency injection
builder.Services.AddScoped<IdGeneratorService>();

var app = builder.Build();

// ✅ Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
