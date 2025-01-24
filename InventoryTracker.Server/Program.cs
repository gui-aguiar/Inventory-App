using InventoryTracker.Database;
using InventoryTracker.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

var dbPath = Environment.GetEnvironmentVariable("DB_PATH") ?? "D:/data/inventory.db";

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection").Replace("__DB_PATH__", dbPath);
var port = Environment.GetEnvironmentVariable("APP_PORT") ?? "5019";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventoryTrackerDBContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();
app.Urls.Add($"http://*:{port}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<InventoryTrackerDBContext>();
    InventoryTrackerDBInitializer.Initialize(dbContext);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
