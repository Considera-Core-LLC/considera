using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Core.Interfaces.MusiqueHub;

public interface IAlbumsRepository : IRepository<Album>
{
    Task AddAlbum(Album album);
    Task<bool> AlbumExists(Album album);
    Task<Album?> GetAlbum(Album album);
    Task<IEnumerable<Album>> GetAlbumsByGenreId(Guid genreId);
    Task<IEnumerable<Album>> GetAlbumsByGenreIds(IEnumerable<Guid> genreIds);
    Task RemoveAlbum(Album album);
    Task RemoveAlbums(IEnumerable<Album> album);
}