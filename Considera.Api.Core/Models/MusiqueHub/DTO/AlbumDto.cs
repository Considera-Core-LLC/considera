// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable CS8618

namespace Considera.Api.Core.Models.MusiqueHub.DTO;

public class AlbumDto : IDto
{
    public string? Id { get; init; }
    public string? AuthorId { get; init; }
    public string? VerifierId { get; init; }
    public string Name { get; init; }
    public DateTime ReleaseDate { get; init; }
    public string? ReleaseType { get; init; }
    public string Description { get; init; }
    public string? Language { get; init; }
    public List<string>? ArtistIds { get; init; }
    public List<string>? GenreIds { get; init; }

    public bool IsValid() =>
        !string.IsNullOrEmpty(Name) && 
        !string.IsNullOrEmpty(Description);
    
    public static Album MapTo(AlbumDto albumDto) =>
        new()
        {
            Id = Guid.TryParse(albumDto.Id, out var id) ? id : Guid.Empty,
            AuthorId = Guid.TryParse(albumDto.AuthorId, out var authorId) ? authorId : Guid.Empty,
            VerifierId = Guid.TryParse(albumDto.VerifierId, out var verifierId) ? verifierId : Guid.Empty,
            Name = albumDto.Name,
            ReleaseDate = albumDto.ReleaseDate,
            ReleaseType = Guid.TryParse(albumDto.ReleaseType, out var releaseType) ? releaseType : Guid.Empty,
            Description = albumDto.Description,
            Language = albumDto.Language,
        };
    
    public static AlbumDto MapFrom(Album album) =>
        new()
        {
            Id = album.Id.ToString(),
            AuthorId = album.AuthorId.ToString(),
            VerifierId = album.VerifierId.ToString(),
            Name = album.Name,
            ReleaseDate = album.ReleaseDate,
            ReleaseType = album.ReleaseType.ToString(),
            Description = album.Description,
            Language = album.Language,
            ArtistIds = album.Artists.Select(a => a.Id.ToString()).ToList(),
            GenreIds = album.Genres.Select(g => g.Id.ToString()).ToList(),
        };
}