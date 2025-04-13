using Microsoft.EntityFrameworkCore;
using PropertyGalla.Data;
using PropertyGalla.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// ✅ Safe, flexible CORS (you can allow only localhost, or everything during development)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()         // Change to .WithOrigins("http://localhost:5500") to restrict
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// ✅ Register DbContext
builder.Services.AddDbContext<PropertyGallaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ✅ Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");  // CORS must come before auth
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//// ✅ Seed Dummy Data on first run (if DB is empty)
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<PropertyGallaContext>();
//    DummySeeder.Seed(db);
//}

app.Run();
