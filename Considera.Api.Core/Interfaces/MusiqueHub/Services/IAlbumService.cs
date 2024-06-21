using Considera.Api.Core.Models.MusiqueHub;
using Considera.Api.Core.Models.MusiqueHub.DTO;

namespace Considera.Api.Core.Interfaces.MusiqueHub.Services;

public interface IAlbumService : IService<AlbumDto>
{
    Task<IEnumerable<Album>> GetAlbums();
    Task<IEnumerable<Album>> GetAlbums(IEnumerable<string> albumIds);
    Task<IEnumerable<Album>> GetAlbums(IEnumerable<Guid> albumIds);
    Task<IEnumerable<Album>> GetAlbumsByGenreId(string genreId);
    Task<IEnumerable<Album>> GetAlbumsByGenreIds(IEnumerable<string> genreIds);
    Task<Album?> GetAlbum(string name);
    Task<IEnumerable<Album>> GetAlbumsFromGenreAlbums(IEnumerable<string> genreAlbumIds);
    Task<bool> HasAlbum(string name);
    Task AddAlbum(Album album, string artistIds, string genreIds);
    Task AddAlbum(Album album, IEnumerable<Guid> artistIds, IEnumerable<Guid> genreIds);
}
