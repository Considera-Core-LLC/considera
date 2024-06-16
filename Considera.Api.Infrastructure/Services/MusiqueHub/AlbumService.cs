using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Interfaces.MusiqueHub.Services;
using ConsideraDevApi.Core.Models.MusiqueHub;

namespace ConsideraDevApi.Infrastructure.Services.MusiqueHub;

public class AlbumService : IAlbumService
{
    private readonly IAlbumsRepository _albumsRepository;
    private readonly IArtistAlbumsRepository _artistAlbumsRepository;
    private readonly IArtistsRepository _artistsRepository;
    private readonly IGenresRepository _genresRepository;

    public AlbumService(
        IAlbumsRepository albumsRepository,
        IArtistAlbumsRepository artistAlbumsRepository,
        IArtistsRepository artistsRepository,
        IGenresRepository genresRepository)
    {
        _albumsRepository = albumsRepository;
        _artistAlbumsRepository = artistAlbumsRepository;
        _artistsRepository = artistsRepository;
        _genresRepository = genresRepository;
    }

    public async Task<IEnumerable<Album>> GetAlbums() => 
        await _albumsRepository.GetAll();
    
    public async Task<IEnumerable<Album>> GetAlbums(IEnumerable<string> albumIds) =>
        await _albumsRepository.Get(albumIds.Select(Guid.Parse));
    
    public async Task<IEnumerable<Album>> GetAlbums(IEnumerable<Guid> albumIds) =>
        await _albumsRepository.Get(albumIds);
    
    public async Task<IEnumerable<Album>> GetAlbumsByGenreId(string genreId) =>
        await _albumsRepository.GetAlbumsByGenreId(Guid.Parse(genreId));
    
    public async Task<IEnumerable<Album>> GetAlbumsByGenreIds(IEnumerable<string> genreIds) =>
        await _albumsRepository.GetAlbumsByGenreIds(genreIds.Select(Guid.Parse));

    public Task<Album?> GetAlbum(string name) => 
        throw new NotImplementedException();

    public async Task<IEnumerable<Album>> GetAlbumsFromGenreAlbums(IEnumerable<string> genreAlbumIds) => 
        (await _artistAlbumsRepository.Get(genreAlbumIds.Select(Guid.Parse)))
        .Select(x => x.Album);

    public Task<bool> HasAlbum(string name) => 
        throw new NotImplementedException();
    
    public async Task AddAlbum(Album album, string artistIds, string genreIds) =>
        await AddAlbum(album, 
            artistIds.Split(",").Select(Guid.Parse), 
            genreIds.Split(",").Select(Guid.Parse));

    public async Task AddAlbum(
        Album album, 
        IEnumerable<Guid> artistIds, 
        IEnumerable<Guid> genreIds)
    {
        await _albumsRepository.AddAlbum(album);
        
        var artists = await _artistsRepository.Get(artistIds);
        await _artistAlbumsRepository.MapArtistsToAlbum(album, artists);
        
        var genres = await _genresRepository.Get(genreIds);
        await _artistAlbumsRepository.MapGenresToAlbum(album, genres);
    }
}
