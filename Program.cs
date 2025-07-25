var builder = WebApplication.CreateBuilder(args);


var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
              throw new InvalidOperationException("No Data Found Here");

builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(ConnectionString));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<Icategories, CategoriesServices>();
builder.Services.AddScoped<IDevices, DevicesServices>();
builder.Services.AddScoped<IGameService, GameService>();

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

app.Run();
