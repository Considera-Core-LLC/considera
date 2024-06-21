using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Core.Interfaces.MusiqueHub;

public interface ISongsRepository : IRepository<Song>
{
    Task<bool> HasSong(Song song);
}