using Microsoft.EntityFrameworkCore;
using Product.API.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("ProductAPIContext") ?? throw new InvalidOperationException("Connection string 'ProductAPIContext' not found.");
Console.WriteLine("API Connection string" + connectionString);

builder.Services.AddDbContext<ProductAPIContext>(options =>
    options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'ProductAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
