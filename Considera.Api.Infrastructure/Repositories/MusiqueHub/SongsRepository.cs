using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Models.MusiqueHub;
using Microsoft.EntityFrameworkCore;

namespace ConsideraDevApi.Infrastructure.Repositories.MusiqueHub;

public class SongsRepository : BaseRepository<Song>, ISongsRepository
{
    public SongsRepository(DbContext context) : base(context) {}

    public async Task<bool> HasSong(Song song) =>
        await Context.Set<Song>().AnyAsync(s => 
            s.Name == song.Name
            && s.AlbumId == song.AlbumId
            && s.Length == song.Length);
}