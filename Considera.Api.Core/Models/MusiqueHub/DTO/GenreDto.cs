#pragma warning disable CS8618

namespace ConsideraDevApi.Core.Models.MusiqueHub.DTO;

public class GenreDto
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public Guid AuthorId { get; set; }
    public Guid VerifierId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Album> Albums { get; set; }
    
    public bool IsValid() =>
        !string.IsNullOrEmpty(Name) && 
        !string.IsNullOrEmpty(Description);

    public static Genre MapTo(GenreDto genreDto) =>
        new()
        {
            Id = genreDto.Id,
            ParentId = genreDto.ParentId,
            AuthorId = genreDto.AuthorId,
            VerifierId = genreDto.VerifierId,
            Name = genreDto.Name,
            Description = genreDto.Description
        };
    
    public static GenreDto MapFrom(Genre genre) =>
        new()
        {
            Id = genre.Id,
            ParentId = genre.ParentId ?? Guid.Empty,
            AuthorId = genre.AuthorId ?? Guid.Empty,
            VerifierId = genre.VerifierId ?? Guid.Empty,
            Name = genre.Name,
            Description = genre.Description ?? string.Empty,
            //Albums = genre.AlbumGenres.Select(x => x.Album).ToList()
        };
}