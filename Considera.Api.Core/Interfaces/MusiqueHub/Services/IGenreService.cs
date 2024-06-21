using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Core.Interfaces.MusiqueHub.Services;

public interface IGenreService
{
    Task<IEnumerable<Genre>> GetAllGenres(bool withAlbums = false, bool withArtists = false);
    Task<IEnumerable<Genre>> GetGenres(string[] genreIds);
    Task<Genre?> GetGenre(string name);
    Task<Genre?> GetGenre(Guid genreId);
    Task<Genre> ModifyGenre(Guid genreId, string name, string desc);
    Task AddGenres(IEnumerable<Genre> genres);
    Task AssignSubgenres(IEnumerable<Genre> genres);
}
