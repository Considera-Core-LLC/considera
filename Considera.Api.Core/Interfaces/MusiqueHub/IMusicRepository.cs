using ConsideraDevApi.Core.Models.MusiqueHub;

namespace ConsideraDevApi.Core.Interfaces.MusiqueHub;

public interface IMusicRepository : IRepository<Music>
{
    Task<IEnumerable<Album>> GetAlbumsFromArtist(Artist artist);
    Task<IEnumerable<Album>> GetAlbumsFromGenre(Genre genre);
    Task<IEnumerable<Album>> GetAlbumsFromSong(Song song);
    
    
    Task<IEnumerable<Artist>> GetArtistsFromAlbum(Album album);
    Task<IEnumerable<Artist>> GetArtistsFromGenre(Genre genre);
    Task<IEnumerable<Artist>> GetArtistsFromSong(Song song);
    
    Task<IEnumerable<Song>> GetSongsFromAlbum(Album album);
    Task<IEnumerable<Song>> GetSongsFromArtist(Artist artist);
    Task<IEnumerable<Song>> GetSongsFromGenre(Genre genre);
    
    Task<IEnumerable<Genre>> GetGenresFromAlbum(Album album);
    Task<IEnumerable<Genre>> GetGenresFromArtist(Artist artist);
    Task<IEnumerable<Genre>> GetGenresFromSong(Song song);

    Task<IEnumerable<Music>> GetMusicFromAlbum(Album album);
    Task<IEnumerable<Music>> GetMusicFromArtist(Artist artist);
    Task<IEnumerable<Music>> GetMusicFromSong(Song song);
    Task<IEnumerable<Music>> GetMusicFromGenre(Genre genre);
    
}