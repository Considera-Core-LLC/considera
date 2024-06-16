using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Interfaces.MusiqueHub.Services;
using ConsideraDevApi.Core.Models.MusiqueHub;
using ConsideraDevApi.Core.Models.MusiqueHub.DTO;

namespace ConsideraDevApi.Infrastructure.Services.MusiqueHub;

public class ArtistService : IArtistService
{
    private readonly IArtistsRepository _artistsRepository;
    private readonly IArtistAlbumsRepository _artistAlbumsRepository;

    public ArtistService(IArtistsRepository artistsRepository, IArtistAlbumsRepository artistAlbumsRepository)
    {
        _artistsRepository = artistsRepository;
        _artistAlbumsRepository = artistAlbumsRepository;
    }
    
    public async Task<Artist?> GetArtist(string id) => 
        await _artistsRepository.Get(Guid.Parse(id));

    public async Task<IEnumerable<Artist>> GetArtists() => 
        await _artistsRepository.GetAll();
    
    public async Task<IEnumerable<Artist>> GetArtists(IEnumerable<string> ids) =>
        await _artistsRepository.Get(ids.Select(Guid.Parse));

    public async Task AddArtist(Artist artist) =>
        await _artistsRepository.Add(artist);

    public async Task AddArtist(ArtistDto artistDto) => 
        await AddArtist(ArtistDto.MapTo(artistDto));
}
