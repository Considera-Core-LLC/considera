using Considera.Api.Core.Models.MusiqueHub;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace Considera.Api.DbContexts;

public class MusiqueHubDbContext : DbContext
{
    public DbSet<Album> Album { get; set; }
    public DbSet<AlbumGenre> AlbumGenre { get; set; }
    public DbSet<Artist> Artist { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Song> Song { get; set; }
    public DbSet<User> User { get; set; }
    
    public MusiqueHubDbContext() { }
    public MusiqueHubDbContext(DbContextOptions<MusiqueHubDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        optionsBuilder.UseSqlServer(
            new ConfigurationBuilder()
                .SetBasePath(Path.Join(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("MusiqueHubDB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>()
            .HasMany(e => e.Genres)
            .WithMany(e => e.Albums)
            .UsingEntity<AlbumGenre>(
                l => l.HasOne<Genre>().WithMany(e => e.AlbumGenres),
                r => r.HasOne<Album>().WithMany(e => e.AlbumGenres));
    }
}