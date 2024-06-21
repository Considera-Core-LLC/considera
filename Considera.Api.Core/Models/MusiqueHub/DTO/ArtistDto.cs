// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable CS8618

namespace Considera.Api.Core.Models.MusiqueHub.DTO;

public class ArtistDto : IDto
{
    public string? Id;
    public string? AuthorId { get; init; }
    public string? VerifierId { get; init; }
    public string Name { get; init; }
    public string Bio { get; init; }
    public string Origin { get; init; }
    public DateTime FormedDate { get; init; }
    
    public bool IsValid() =>
        !string.IsNullOrEmpty(Name) && 
        !string.IsNullOrEmpty(Bio);

    public static Artist MapTo(ArtistDto artistDto) =>
        new()
        {
            Id = Guid.TryParse(artistDto.Id, out var id) ? id : Guid.Empty,
            AuthorId = Guid.TryParse(artistDto.AuthorId, out var aId) ? aId : Guid.Empty,
            VerifierId = Guid.TryParse(artistDto.VerifierId, out var vId) ? vId : Guid.Empty,
            Name = artistDto.Name,
            Bio = artistDto.Bio,
            Origin = artistDto.Origin,
            FormedDate = artistDto.FormedDate
        };
    
    public static ArtistDto MapFrom(Artist artist) =>
        new()
        {
            Id = artist.Id.ToString(),
            AuthorId = artist.AuthorId.ToString(),
            VerifierId = artist.VerifierId.ToString(),
            Name = artist.Name,
            Bio = artist.Bio ?? string.Empty,
            Origin = artist.Origin,
            FormedDate = artist.FormedDate
        };
}