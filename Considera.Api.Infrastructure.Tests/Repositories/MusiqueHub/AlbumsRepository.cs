using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Infrastructure.Tests.Repositories.MusiqueHub;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class AlbumsRepository
{
    [Test]
    public Task GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Album?> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Album>> Get(IEnumerable<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public Task<Album?> Add(Album entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Album>> Add(IEnumerable<Album> entities)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Has(Album entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Album>> SearchAlbum(string artistName, string albumName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AlbumExists(string artistName, string albumName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AlbumExists(Album album)
    {
        throw new NotImplementedException();
    }

    public Task AddAlbum(Album album, IEnumerable<Artist> artists)
    {
        throw new NotImplementedException();
    }

    public Task AddAlbum(Album album)
    {
        throw new NotImplementedException();
    }

    public Task<Album?> GetAlbum(Album album)
    {
        throw new NotImplementedException();
    }
}