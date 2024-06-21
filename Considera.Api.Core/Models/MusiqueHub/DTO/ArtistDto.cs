#pragma warning disable CS8618

namespace Considera.Api.Core.Models.MusiqueHub.DTO;

public class ArtistDto
{
    public Guid Id { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? VerifierId { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public string Origin { get; set; }
    public DateTime FormedDate { get; set; }

    public List<Genre> Genres { get; set; }
    public List<Artist> Artists { get; set; }
    
    public bool IsValid() =>
        !string.IsNullOrEmpty(Name) && 
        !string.IsNullOrEmpty(Bio);

    public static Artist MapTo(ArtistDto artistDto) =>
        new()
        {
            Id = artistDto.Id,
            AuthorId = artistDto.AuthorId,
            VerifierId = artistDto.VerifierId,
            Name = artistDto.Name,
            Bio = artistDto.Bio,
            Origin = artistDto.Origin,
            FormedDate = artistDto.FormedDate
        };
    
    public static ArtistDto MapFrom(Artist artist) =>
        new()
        {
            Id = artist.Id,
            AuthorId = artist.AuthorId,
            VerifierId = artist.VerifierId,
            Name = artist.Name,
            Bio = artist.Bio ?? string.Empty,
            Origin = artist.Origin,
            FormedDate = artist.FormedDate
        };
}