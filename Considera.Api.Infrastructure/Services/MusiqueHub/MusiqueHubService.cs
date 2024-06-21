using Considera.Api.Core.Interfaces.MusiqueHub;
using Considera.Api.Core.Interfaces.MusiqueHub.Services;
using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Infrastructure.Services.MusiqueHub;

public class MusiqueHubService : IMusiqueHubService
{
    private readonly IAlbumsRepository _albumsRepository;
    private readonly IArtistsRepository _artistsRepository;
    private readonly IArtistAlbumsRepository _artistAlbumsRepository;
    private readonly IGenresRepository _genresRepository;
    private readonly IMusicRepository _musicRepository;
    private readonly ISongsRepository _songsRepository;
    private readonly IUsersRepository _usersRepository;

    public MusiqueHubService(
        IAlbumsRepository albumsRepository, 
        IArtistsRepository artistsRepository, 
        IArtistAlbumsRepository artistAlbumsRepository, 
        IGenresRepository genresRepository, 
        IMusicRepository musicRepository, 
        ISongsRepository songsRepository, 
        IUsersRepository usersRepository)
    {
        _albumsRepository = albumsRepository;
        _artistsRepository = artistsRepository;
        _artistAlbumsRepository = artistAlbumsRepository;
        _genresRepository = genresRepository;
        _musicRepository = musicRepository;
        _songsRepository = songsRepository;
        _usersRepository = usersRepository;
    }

    // Mappers
    public async Task<IEnumerable<AlbumGenre>> GetGenreAlbumsFromGenres(IEnumerable<string> genreIds) => 
        await _artistAlbumsRepository.GetGenreAlbumsFromGenres(genreIds.Select(Guid.Parse));

    // Users
    public async Task<IEnumerable<User>> GetAllUsers() => 
        await _usersRepository.GetAll();
    
    public async Task<bool> HasUser(string username) => 
        await _usersRepository.HasUser(username);
    
    public async Task<UserProtected> HasUser(string username, string password)
    {
        var result = await _usersRepository.HasUser(username, password);
        return result == null ? new UserProtected(false) : new UserProtected
        {
            Id = result.Id,
            Username = result.Username,
            IsLoggedIn = true
        };
    }

    public async Task<UserProtected> AddUser(string username, string password)
    {
        var result = await _usersRepository.AddUser(username, password);
        Console.WriteLine(result);
        return result == null ? new UserProtected() : new UserProtected
        {
            Id = result.Id,
            Username = result.Username,
            IsLoggedIn = true
        };
    }

    public async Task<User?> AddUser(User user) =>
        await _usersRepository.Add(user);
}