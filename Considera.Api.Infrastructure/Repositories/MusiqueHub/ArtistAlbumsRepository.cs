using Considera.Api.Core.Interfaces.MusiqueHub;
using Considera.Api.Core.Models.MusiqueHub;
using Microsoft.EntityFrameworkCore;

namespace Considera.Api.Infrastructure.Repositories.MusiqueHub;

/// <summary>
/// Albums repository for the MusiqueHub database.
/// </summary>
public class ArtistAlbumsRepository : BaseRepository<ArtistAlbum>, IArtistAlbumsRepository
{
    // why cant the methods be static?
    private readonly IArtistsRepository _artistsRepository;
    private readonly IAlbumsRepository _albumsRepository;
    private readonly IGenresRepository _genresRepository;

    // todo: i really need to do unit tests for experimenting with how to actually add to mappers
    public ArtistAlbumsRepository(
        DbContext context, 
        IArtistsRepository artistsRepository,
        IAlbumsRepository albumsRepository, 
        IGenresRepository genresRepository) : base(context)
    {
        _artistsRepository = artistsRepository;
        _albumsRepository = albumsRepository;
        _genresRepository = genresRepository;
    }
    
    // todo: broken
    public async Task<bool> AlbumGenreExists(Album album, Genre genre) =>
        await Context.Set<AlbumGenre>().AnyAsync(aa =>
            aa.GenreId.ToString() == album.Name 
            && aa.GenreId.ToString() == genre.Name);
    
    public async Task<bool> AlbumHasArtist(Album album, Artist artist) =>
        await Context.Set<ArtistAlbum>().AnyAsync(aa =>
            aa.Artist.Name == artist.Name 
            && aa.Album.Name == album.Name);

    /// <summary>
    /// Adds an album with respect to artists.
    /// </summary>
    /// <param name="album"></param>
    /// <param name="artists"></param>
    public async Task MapArtistsToAlbum(Album album, IEnumerable<Artist> artists)
    {
        var artistAlbums = new List<ArtistAlbum>();

        foreach (var artist in artists.ToList())
        {
            if (!await _artistsRepository.ArtistExists(artist)) continue;
            if (!await _albumsRepository.AlbumExists(album)) continue;
            //if (await AlbumHasArtist(album, artist)) continue;

            var fetchedAlbum = await _albumsRepository.GetAlbum(album);
            
            if (fetchedAlbum == null) continue;

            artistAlbums.Add(new ArtistAlbum
            {
                ArtistId = artist.Id,
                Artist = artist,
                AlbumId = fetchedAlbum.Id,
                Album = fetchedAlbum,
            });
        }

        if (artistAlbums.Any())
            await Context
                .Set<ArtistAlbum>()
                .AddRangeAsync(artistAlbums);

        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Adds an album with respect to genres.
    /// </summary>
    /// <param name="album"></param>
    /// <param name="genres"></param>
    public async Task MapGenresToAlbum(Album album, IEnumerable<Genre> genres)
    {
        var albumGenres = new List<AlbumGenre>();

        foreach (var genre in genres.ToList())
        {
            if (!await _genresRepository.GenreExists(genre)) continue;
            if (!await _albumsRepository.AlbumExists(album)) continue;
            if (await AlbumGenreExists(album, genre)) continue;

            var fetchedAlbum = await _albumsRepository.GetAlbum(album);
            
            if (fetchedAlbum == null) continue;

            albumGenres.Add(new AlbumGenre
            {
                AlbumId = fetchedAlbum.Id,
                //Album = fetchedAlbum,
                GenreId = genre.Id,
                //Genre = genre
            });
        }

        if (albumGenres.Any())
        {
            var list = albumGenres.ToList();
            await Context
                .Set<AlbumGenre>()
                .AddRangeAsync(list);
        }

        await Context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<AlbumGenre>> GetGenreAlbumsFromGenres(IEnumerable<Guid> genreIds) =>
        await Context
            .Set<AlbumGenre>()
            .Where(x => genreIds.Contains(x.GenreId))
            .ToListAsync();
}