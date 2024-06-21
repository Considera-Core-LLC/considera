using Considera.Api.Core.Models.MusiqueHub;
using Considera.Api.Core.Models.MusiqueHub.DTO;

namespace Considera.Api.Core.Interfaces.MusiqueHub.Services;

public interface IArtistService : IService<ArtistDto>
{
    Task<Artist?> GetArtist(string id);
    Task<IEnumerable<Artist>> GetArtists();
    Task<IEnumerable<Artist>> GetArtists(IEnumerable<string> ids);
}
