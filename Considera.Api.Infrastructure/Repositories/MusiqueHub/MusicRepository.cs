using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Models.MusiqueHub;
using Microsoft.EntityFrameworkCore;

namespace ConsideraDevApi.Infrastructure.Repositories.MusiqueHub;

public class MusicRepository : BaseRepository<Music>, IMusicRepository
{
    public MusicRepository(DbContext context) : base(context) {}

    // Albums
    public async Task<IEnumerable<Album>> GetAlbumsFromArtist(Artist artist) =>
        await (from music in Context.Set<Music>()
            join album in Context.Set<Album>()
                on music.AlbumId equals album.Id
            where music.ArtistId == artist.Id
            select album).ToListAsync();
    
    public async Task<IEnumerable<Album>> GetAlbumsFromGenre(Genre genre) =>
        await (from music in Context.Set<Music>()
            join album in Context.Set<Album>()
                on music.AlbumId equals album.Id
            where music.GenreId == genre.Id
            select album).ToListAsync();
    
    public async Task<IEnumerable<Album>> GetAlbumsFromSong(Song song) =>
        await (from music in Context.Set<Music>()
            join album in Context.Set<Album>()
                on music.AlbumId equals album.Id
            where music.SongId == song.Id
            select album).ToListAsync();
    
    // Artists
    public async Task<IEnumerable<Artist>> GetArtistsFromAlbum(Album album) =>
        await (from music in Context.Set<Music>()
            join artist in Context.Set<Artist>()
                on music.ArtistId equals artist.Id
            where music.AlbumId == album.Id
            select artist).ToListAsync();
    
    public async Task<IEnumerable<Artist>> GetArtistsFromGenre(Genre genre) =>
        await (from music in Context.Set<Music>()
            join artist in Context.Set<Artist>()
                on music.ArtistId equals artist.Id
            where music.GenreId == genre.Id
            select artist).ToListAsync();
    
    public async Task<IEnumerable<Artist>> GetArtistsFromSong(Song song) =>
        await (from music in Context.Set<Music>()
            join artist in Context.Set<Artist>()
                on music.ArtistId equals artist.Id
            where music.SongId == song.Id
            select artist).ToListAsync();
    
    // Songs
    public async Task<IEnumerable<Song>> GetSongsFromAlbum(Album album) =>
        await (from music in Context.Set<Music>()
            join song in Context.Set<Song>()
                on music.SongId equals song.Id
            where music.AlbumId == album.Id
            select song).ToListAsync();
    
    public async Task<IEnumerable<Song>> GetSongsFromArtist(Artist artist) =>
        await (from music in Context.Set<Music>()
            join song in Context.Set<Song>()
                on music.SongId equals song.Id
            where music.ArtistId == artist.Id
            select song).ToListAsync();
    
    public async Task<IEnumerable<Song>> GetSongsFromGenre(Genre genre) =>
        await (from music in Context.Set<Music>()
            join song in Context.Set<Song>()
                on music.SongId equals song.Id
            where music.GenreId == genre.Id
            select song).ToListAsync();
    
    // Genres
    public async Task<IEnumerable<Genre>> GetGenresFromAlbum(Album album) =>
        await (from music in Context.Set<Music>()
            join genre in Context.Set<Genre>()
                on music.GenreId equals genre.Id
            where music.AlbumId == album.Id
            select genre).ToListAsync();
    
    public async Task<IEnumerable<Genre>> GetGenresFromArtist(Artist artist) =>
        await (from music in Context.Set<Music>()
            join genre in Context.Set<Genre>()
                on music.GenreId equals genre.Id
            where music.ArtistId == artist.Id
            select genre).ToListAsync();
    
    public async Task<IEnumerable<Genre>> GetGenresFromSong(Song song) =>
        await (from music in Context.Set<Music>()
            join genre in Context.Set<Genre>()
                on music.GenreId equals genre.Id
            where music.SongId == song.Id
            select genre).ToListAsync();
    
    // Music
    public async Task<IEnumerable<Music>> GetMusicFromAlbum(Album album) =>
        await Context.Set<Music>().Where(m => m.AlbumId == album.Id).ToListAsync();
    
    public async Task<IEnumerable<Music>> GetMusicFromArtist(Artist artist) =>
        await Context.Set<Music>().Where(m => m.ArtistId == artist.Id).ToListAsync();
    
    public async Task<IEnumerable<Music>> GetMusicFromSong(Song song) =>
        await Context.Set<Music>().Where(m => m.SongId == song.Id).ToListAsync();
    
    public async Task<IEnumerable<Music>> GetMusicFromGenre(Genre genre) =>
        await Context.Set<Music>().Where(m => m.GenreId == genre.Id).ToListAsync();
}