using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Models.MusiqueHub;
using Microsoft.EntityFrameworkCore;

namespace ConsideraDevApi.Infrastructure.Repositories.MusiqueHub;

public class AlbumsRepository : BaseRepository<Album>, IAlbumsRepository
{
    public AlbumsRepository(DbContext context) : base(context) {}

    public async Task AddAlbum(Album album)
    {
        if (await AlbumExists(album)) return;
        
        await Context.Set<Album>().AddAsync(album);
        await Context.SaveChangesAsync();
    }
    
    // todo: need to create a foreign key constraint album's fields
    public async Task<bool> AlbumExists(Album album) =>
        await Context.Set<Album>().AnyAsync(x =>
            x.Name == album.Name &&
            x.ReleaseDate.Date == album.ReleaseDate.Date);
    
    public async Task<Album?> GetAlbum(Album album) =>
        await Context
            .Set<Album>()
            .FirstOrDefaultAsync(x => 
                x.Name == album.Name && 
                x.ReleaseDate.Date == album.ReleaseDate.Date);
    
    public async Task<IEnumerable<Album>> GetAlbumsByGenreId(Guid genreId)
    {
        /*
        var albums = await Context
            .Set<Album>()
            .Include(a => a.AlbumGenres)
            .ThenInclude(ag => ag.Genre)
            .Where(a => a.AlbumGenres.Any(ag => ag.GenreId == genreId))
            .ToListAsync();
*/
        return null;
    }
    
    public async Task<IEnumerable<Album>> GetAlbumsByGenreIds(IEnumerable<Guid> genreIds)
    {
        var genreAlbums = await Context
            .Set<AlbumGenre>()
            .Where(x => genreIds.Contains(x.GenreId))
            .ToListAsync();

        var albums = genreAlbums
            .Join(
                Context.Set<Album>(),
                x => x.AlbumId,
                y => y.Id,
                (x, y) => y)
            .ToList();

        return albums;
        
        return await Context
            .Set<AlbumGenre>()
            .Where(x => genreIds.Contains(x.GenreId))
            .Join(
                Context.Set<Album>(),
                x => x.AlbumId,
                y => y.Id,
                (x, y) => y)
            .ToListAsync();
    }

    public async Task RemoveAlbum(Album album)
    {
        Context.Set<Album>().Remove(album);
        await Context.SaveChangesAsync();
    }
    
    public async Task RemoveAlbums(IEnumerable<Album> albums)
    {
        Context.Set<Album>().RemoveRange(albums);
        await Context.SaveChangesAsync();
    }
}