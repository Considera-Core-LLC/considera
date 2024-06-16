using System.Collections;
using System.Collections.Immutable;
using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Models.MusiqueHub;
using Microsoft.EntityFrameworkCore;

namespace ConsideraDevApi.Infrastructure.Repositories.MusiqueHub;

public class GenresRepository : BaseRepository<Genre>, IGenresRepository
{
    public DbSet<Genre> Genres => Context.Set<Genre>();
    public DbSet<Album> Albums => Context.Set<Album>();
    public DbSet<AlbumGenre> AlbumGenres => Context.Set<AlbumGenre>();
    
    public GenresRepository(DbContext context) : base(context) {}
    
    public async Task AddGenre(Genre genre)
    {
        if (await GenreExists(genre)) return;
        
        await Context.Set<Genre>().AddAsync(genre);
        await Context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Genre>> AssignSubgenres(IEnumerable<Genre> genres)
    {
        var transaction = await Context.Database.BeginTransactionAsync();
        try
        {
            var genresList = genres.ToList();
            foreach (var genre in genresList.ToArray())
            {
                var existingGenre = await FetchByName(genre.Name, false);
                if (existingGenre != null)
                {
                    genre.Id = existingGenre.Id;
                    Context.Update(genre);
                }
                else genresList.Remove(genre);
            }
            await Context.SaveChangesAsync(); // Asynchronous save to the database
            await transaction.CommitAsync(); // Commit transaction on success
            
            return genresList;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(); // Rollback transaction on error
            Console.WriteLine(ex); // Rethrow the exception for further handling
        }
        finally
        {
            transaction.Dispose(); // Ensure the transaction is disposed
        }
        
        return ImmutableArray<Genre>.Empty;
    }

    public async Task<Genre> ModifyGenre(Guid genreId, string name, string desc)
    {
        var genre = await FetchById(genreId, false);
        
        if (genre == null) return new Genre();
        
        genre.Name = name;
        genre.Description = desc;
        
        Context.Set<Genre>().Update(genre);
        
        await Context.SaveChangesAsync();
        return genre;
    }

    public async Task<bool> GenreExists(Genre genre) =>
        await Context
            .Set<Genre>()
            .AnyAsync(g => g.Name == genre.Name);

    /// <status>
    /// Incomplete
    /// </status>
    /// <notes>
    /// Need to make a better pipeline
    /// </notes>
    public async Task<IEnumerable<Genre>> FetchAllWithAlbums()
    {
        var genres = Genres.Include(x => x.Albums).ToList();
        return genres;

        var genreIds = genres
            .Select(x => x.Id)
            .ToList();
        
        var albumGenres = AlbumGenres
            .Where(x => genreIds.Contains(x.GenreId))
            .ToList();
        
        var albums = Albums
            .Where(x => albumGenres
                .Select(y => y.AlbumId)
                .Contains(x.Id))
            .ToList();

        return genres.Select(x =>
        {
            x.AlbumGenres = albumGenres
                .Where(y => y.GenreId == x.Id)
                .ToList();
            x.Albums = albums.Where(y => y.AlbumGenres
                    .Select(z => z.GenreId)
                    .Contains(x.Id))
                .ToList();
            return x;
        });
    }

    public async Task<Genre?> FetchByGenre(Genre genre, bool readOnly = true) =>
        await FetchByName(genre.Name, readOnly);
    
    public async Task<Genre?> FetchByName(string name, bool readOnly = true) =>
        await (readOnly 
            ? Context.Set<Genre>().FirstOrDefaultAsync(g => g.Name == name) 
            : Context.Set<Genre>().AsNoTracking().FirstOrDefaultAsync(g => g.Name == name));
    
    public async Task<Genre?> FetchById(Guid genreId, bool readOnly = true) =>
        await (readOnly 
            ? Context.Set<Genre>().FirstOrDefaultAsync(g => g.Id == genreId) 
            : Context.Set<Genre>().AsNoTracking().FirstOrDefaultAsync(g => g.Id == genreId));
}