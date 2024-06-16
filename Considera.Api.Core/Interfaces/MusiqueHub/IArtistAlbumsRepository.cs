using ConsideraDevApi.Core.Models.MusiqueHub;

namespace ConsideraDevApi.Core.Interfaces.MusiqueHub;

public interface IArtistAlbumsRepository : IRepository<ArtistAlbum>
{
    Task<bool> AlbumHasArtist(Album album, Artist artist);
    Task<bool> AlbumGenreExists(Album album, Genre genre);
    Task MapArtistsToAlbum(Album album, IEnumerable<Artist> artists);
    Task MapGenresToAlbum(Album album, IEnumerable<Genre> genres);
    Task<IEnumerable<AlbumGenre>> GetGenreAlbumsFromGenres(IEnumerable<Guid> genreIds);
}