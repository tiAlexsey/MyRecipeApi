using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Services.Database;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Ingredient> Ingredient { get; set; } = null!;
    public DbSet<Dish> Dish { get; set; } = null!;
    public DbSet<LinkIngredients> LinkIngredients { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseNpgsql();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}