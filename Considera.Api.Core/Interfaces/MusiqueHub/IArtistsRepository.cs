using ConsideraDevApi.Core.Models.MusiqueHub;

namespace ConsideraDevApi.Core.Interfaces.MusiqueHub;

public interface IArtistsRepository : IRepository<Artist>
{
    Task AddArtist(Artist artist);
    Task<bool> ArtistExists(Artist artist);
    Task RemoveArtist(Artist artist);
    Task RemoveArtists(IEnumerable<Artist> artists);
}