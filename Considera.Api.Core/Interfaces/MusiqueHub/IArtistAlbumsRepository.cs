using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Core.Interfaces.MusiqueHub;

public interface IArtistAlbumsRepository : IRepository<AlbumArtist>
{
    Task MapArtistsToAlbum(Album album, IEnumerable<Artist> artists);
    Task MapGenresToAlbum(Album album, IEnumerable<Genre> genres);
    Task<IEnumerable<AlbumGenre>> GetGenreAlbumsFromGenres(IEnumerable<Guid> genreIds);
}