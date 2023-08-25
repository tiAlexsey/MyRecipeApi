using Domain.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Database;
using Services.Database.Repository;

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.EnableAnnotations(); });

var app = builder.Build();

app.UseCors(options => { options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });

app.UseSwagger();
app.UseSwaggerUI();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();