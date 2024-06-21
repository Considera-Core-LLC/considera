using Considera.Api.Core.Interfaces.MusiqueHub;
using Considera.Api.Core.Models.MusiqueHub;
using Microsoft.EntityFrameworkCore;

namespace Considera.Api.Infrastructure.Repositories.MusiqueHub;

public class SongsRepository : BaseRepository<Song>, ISongsRepository
{
    public SongsRepository(DbContext context) : base(context) {}

    public async Task<bool> HasSong(Song song) =>
        await Context.Set<Song>().AnyAsync(s => 
            s.Name == song.Name
            && s.AlbumId == song.AlbumId
            && s.Length == song.Length);
}