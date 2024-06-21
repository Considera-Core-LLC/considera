using Considera.Api.Core.Interfaces.MusiqueHub;
using Considera.Api.Core.Models.MusiqueHub;
using Microsoft.EntityFrameworkCore;

namespace Considera.Api.Infrastructure.Repositories.MusiqueHub;

public class ArtistsRepository : BaseRepository<Artist>, IArtistsRepository
{
    public ArtistsRepository(DbContext context) : base(context) {}

    public async Task AddArtist(Artist artist)
    {
        if (await ArtistExists(artist)) return;
        
        await Context.Set<Artist>().AddAsync(artist);
        await Context.SaveChangesAsync();
    }
    
    public async Task<bool> ArtistExists(Artist artist) =>
        await Context
            .Set<Artist>()
            .AnyAsync(a => a.Name == artist.Name);
    
    public async Task RemoveArtist(Artist artist)
    {
        Context.Set<Artist>().Remove(artist);
        await Context.SaveChangesAsync();
    }
    
    public async Task RemoveArtists(IEnumerable<Artist> artists)
    {
        Context.Set<Artist>().RemoveRange(artists);
        await Context.SaveChangesAsync();
    }
}