using MangaReaderR.Data;
using MangaReaderR.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services in dependency order
builder.Services.AddSingleton<FileLockProvider>();
builder.Services.AddSingleton<LocalStorage>();
builder.Services.AddSingleton<MangaService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSession();
// ✅ Add session support
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add MVC support
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Enable detailed error page in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

// ✅ Enable session middleware
app.UseSession();

// Map default route: HomeController.Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();