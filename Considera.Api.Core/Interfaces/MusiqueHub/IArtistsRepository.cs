using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Core.Interfaces.MusiqueHub;

public interface IArtistsRepository : IRepository<Artist>
{
    Task AddArtist(Artist artist);
    Task<bool> ArtistExists(Artist artist);
    Task RemoveArtist(Artist artist);
    Task RemoveArtists(IEnumerable<Artist> artists);
}