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

SqliteConnection connection;
if (builder.Environment.IsDevelopment())
{
    connection = new SqliteConnection("DataSource=:memory:");
    connection.Open();
}
else
{
    connection = new SqliteConnection($"DataSource={dbPath}");
}

builder.Services.AddDbContext<InventoryTrackerDBContext>(options =>
    options.UseSqlite(connection));

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<InventoryTrackerDBContext>();
    dbContext.Database.EnsureCreated();

    if (builder.Environment.IsDevelopment())
    {
        var scriptPath = "..\\DatabaseDocker\\populate-database.sql";
        var sqlScript = File.ReadAllText(scriptPath);
        using var command = connection.CreateCommand();
        foreach (var sql in sqlScript.Split(";", StringSplitOptions.RemoveEmptyEntries))
        {
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
