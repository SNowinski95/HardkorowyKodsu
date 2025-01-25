using DbAPI.DB;
using DbAPI.DB.Repository;
using DbAPI.DB.Repository.Interfaces;
using DbAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
//Why not JWT? becuse its realy havy for that option and simple middleware token validation is enouth
app.UseTokenValidation();
app.Run();
