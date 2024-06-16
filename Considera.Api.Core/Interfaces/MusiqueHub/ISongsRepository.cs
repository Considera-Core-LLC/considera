using ConsideraDevApi.Core.Models.MusiqueHub;

namespace ConsideraDevApi.Core.Interfaces.MusiqueHub;

public interface ISongsRepository : IRepository<Song>
{
    Task<bool> HasSong(Song song);
}