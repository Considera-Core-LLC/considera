using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Core.Interfaces.MusiqueHub.Services;

public interface IMusiqueHubService
{
    // Mappers
    Task<IEnumerable<AlbumGenre>> GetGenreAlbumsFromGenres(IEnumerable<string> genreIds);

    // Users
    Task<IEnumerable<User>> GetAllUsers();
    Task<bool> HasUser(string username);
    Task<UserProtected> HasUser(string username, string password);
    Task<UserProtected> AddUser(string username, string password);
}