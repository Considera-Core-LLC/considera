#pragma warning disable CS8618

namespace Considera.Api.Core.Models.MusiqueHub.DTO;

public class AlbumDto
{
    public string Id { get; set; }
    public string AuthorId { get; set; }
    public string VerifierId { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ReleaseType { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }

    public Album ToAlbum()
    {
        return new Album
        {
            Id = Guid.TryParse(Id, out var id) ? id : Guid.Empty,
            AuthorId = Guid.TryParse(AuthorId, out var authorId) ? authorId : Guid.Empty,
            VerifierId = Guid.TryParse(VerifierId, out var verifierId) ? verifierId : Guid.Empty,
            Name = Name,
            ReleaseDate = ReleaseDate,
            ReleaseType = Guid.TryParse(ReleaseType, out var releaseType) ? releaseType : Guid.Empty,
            Description = Description,
            Language = Language
        };
    }
}