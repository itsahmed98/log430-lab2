using Microsoft.EntityFrameworkCore;
using magasincentral.Services;
using magasincentral.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MagasinContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? Environment.GetEnvironmentVariable("DB_CONNECTION")
        ?? "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=magasin";

    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<ProduitService>();
builder.Services.AddScoped<RapportService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MagasinContext>();
    dbContext.Database.Migrate();
    DataSeeder.Seed(dbContext);
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
