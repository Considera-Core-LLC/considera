using ConsideraDevApi.Core.Models.MusiqueHub;
using ConsideraDevApi.Core.Models.MusiqueHub.DTO;

namespace ConsideraDevApi.Core.Interfaces.MusiqueHub.Services;

public interface IGenreService
{
    Task<IEnumerable<Genre>> GetAllGenres();
    Task<IEnumerable<Genre>> GetAllGenresWithAlbums();
    Task<IEnumerable<Genre>> GetGenres(string[] genreIds);
    Task<Genre?> GetGenre(string name);
    Task<Genre?> GetGenre(Guid genreId);
    Task<Genre> ModifyGenre(Guid genreId, string name, string desc);
    Task AddGenres(IEnumerable<Genre> genres);
    Task AssignSubgenres(IEnumerable<Genre> genres);
}
