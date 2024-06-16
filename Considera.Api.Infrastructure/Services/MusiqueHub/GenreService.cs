using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Interfaces.MusiqueHub.Services;
using ConsideraDevApi.Core.Models.MusiqueHub;
using ConsideraDevApi.Core.Models.MusiqueHub.DTO;

namespace ConsideraDevApi.Infrastructure.Services.MusiqueHub;

public class GenreService : IGenreService
{
    private readonly IGenresRepository _genresRepository;
    private readonly IArtistAlbumsRepository _artistAlbumsRepository;
    private IAlbumsRepository _albumsRepository;

    public GenreService(IGenresRepository genresRepository, IArtistAlbumsRepository artistAlbumsRepository, IAlbumsRepository albumsRepository)
    {
        _genresRepository = genresRepository;
        _artistAlbumsRepository = artistAlbumsRepository;
        _albumsRepository = albumsRepository;
    }

    public async Task<IEnumerable<Genre>> GetAllGenres() => 
        await _genresRepository.GetAll();
    
    public async Task<IEnumerable<Genre>> GetAllGenresWithAlbums()
    {
        return (await _genresRepository.FetchAllWithAlbums()).ToList();
    }

    public async Task<IEnumerable<Genre>> GetGenres(string[] genreIds) =>
        await _genresRepository.Get(genreIds.Select(Guid.Parse));
    
    public async Task<Genre?> GetGenre(string name) =>
        await _genresRepository.FetchByName(name);
    
    public async Task<Genre?> GetGenre(Guid genreId) =>
        await _genresRepository.FetchById(genreId);

    public async Task<Genre> ModifyGenre(Guid genreId, string name, string desc) =>
        await _genresRepository.ModifyGenre(genreId, name, desc);
    
    public async Task AddGenres(IEnumerable<Genre> genres)
    {
        foreach (var genre in genres)
            await _genresRepository.AddGenre(genre);
    }

    public async Task AssignSubgenres(IEnumerable<Genre> genres) =>
        await _genresRepository.AssignSubgenres(genres);
}
