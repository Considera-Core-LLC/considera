using Considera.Api.Core.Models.Games;
using Microsoft.EntityFrameworkCore;

namespace Considera.Api.DbContexts;

public class GamesDbContext : DbContext
{
    public DbSet<IdleResearch>? IdleResearch { get; set; }
    
    public GamesDbContext() { }
    public GamesDbContext(DbContextOptions<GamesDbContext> options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        optionsBuilder.UseSqlServer(
            new ConfigurationBuilder()
                .SetBasePath(Path.Join(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("GamesDB"));
    }
}