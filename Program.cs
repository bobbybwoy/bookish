using bookish.DataAccessLayer;
using bookish.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adding the DbContext...
// builder.Services.AddDbContext<MvcMovieContext>(options =>
//         options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext"))
builder.Services.AddDbContext<BookishContext>();
builder.Services.AddTransient<DatabaseSeed>();

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

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeed>();
    seeder.Seed();
}

app.Run();
