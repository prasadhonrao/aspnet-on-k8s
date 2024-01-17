using Product.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Access configuration
var configuration = builder.Configuration;
// Access a specific configuration value
var apiUrl = configuration["ApiConfigs:product:Uri"];
Console.WriteLine("UI: " + apiUrl);

//builder.Services.AddHttpClient<IProductService, ProductService>(client =>
//{
//    client.BaseAddress = new Uri(apiUrl);
//});

builder.Services.AddHttpClient<IProductService, ProductService>(
    (provider, client) => {
        client.BaseAddress = new Uri(provider.GetService<IConfiguration>()?["ApiConfigs:product:Uri"] ?? throw new InvalidOperationException("Missing config"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
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
