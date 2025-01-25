using InventoryTracker.Database;
using InventoryTracker.DependencyInjection;
using InventoryTracker.Server.AutoMappers;
using InventoryTracker.Server.Middlewares;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

var dbPath = Environment.GetEnvironmentVariable("DB_PATH") ?? "D:/data/inventory.db";

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection").Replace("__DB_PATH__", dbPath);
var port = Environment.GetEnvironmentVariable("APP_PORT") ?? "5019";

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

builder.Services.AddDbContext<InventoryTrackerDBContext>(options =>
    options.UseSqlite(connection)); // Registra o contexto com a conexão compartilhada
/*
 context.Database.OpenConnection();
context.Database.EnsureCreated();
 */
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();
app.Urls.Add($"http://*:{port}");

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<InventoryTrackerDBContext>();
    dbContext.Database.EnsureCreated();

    var scriptPath = "D:\\GitHubRepos\\VelozientApp\\DatabaseDocker\\populate-database.sql";
    var sqlScript = File.ReadAllText(scriptPath);
    using var command = connection.CreateCommand();
    foreach (var sql in sqlScript.Split(";", StringSplitOptions.RemoveEmptyEntries))
    {
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
