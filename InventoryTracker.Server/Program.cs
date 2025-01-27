using InventoryTracker.Database;
using InventoryTracker.DependencyInjection;
using InventoryTracker.Server.Middlewares;
using InventoryTracker.Utils;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

var dbPath = Environment.GetEnvironmentVariable("DB_PATH") ?? "D:/data/inventory.db";
var port = Environment.GetEnvironmentVariable("APP_PORT") ?? "5019";

builder.Services.AddDbContext<InventoryTrackerDBContext>(options =>
{
    var connectionString = builder.Environment.IsDevelopment()
        ? "DataSource=:memory:;Pooling=False"
        : $"DataSource={dbPath};Pooling=False";

    options.UseSqlite(connectionString);
}, ServiceLifetime.Scoped);

var allowedOrigins = "AllowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins, policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()                   
              .AllowAnyMethod();                  
    });
});

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();
app.Urls.Add($"http://*:{port}");

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseCors(allowedOrigins);

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<InventoryTrackerDBContext>();
    dbContext.Database.EnsureCreated();

    if (builder.Environment.IsDevelopment())
    {
        var scriptPath = "..\\DatabaseDocker\\populate-database.sql";
        var sqlScript = File.ReadAllText(scriptPath);
        foreach (var sql in sqlScript.Split(";", StringSplitOptions.RemoveEmptyEntries))
        {
            dbContext.Database.ExecuteSqlRaw(sql);
        }
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
