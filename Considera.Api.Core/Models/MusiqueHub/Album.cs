using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsideraDevApi.Core.Interfaces;
#pragma warning disable CS8618

namespace ConsideraDevApi.Core.Models.MusiqueHub;

[Table("Albums")]
public class Album : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? VerifierId { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Guid? ReleaseType { get; set; }
    public string Description { get; set; }
    public string? Language { get; set; }
    
    public List<Genre> Genres { get; set; }
    public List<AlbumGenre> AlbumGenres { get; set; }
}