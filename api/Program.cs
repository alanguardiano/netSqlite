using api.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDbConnection>(_ =>
    new SqliteConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AppDbContextWithDapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.

using(var scope = app.Services.CreateScope())
{
    //cria pelo entity framework
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();

    //cria pelo DAPPER
    //var dapperContext = scope.ServiceProvider.GetRequiredService<AppDbContextWithDapper>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
