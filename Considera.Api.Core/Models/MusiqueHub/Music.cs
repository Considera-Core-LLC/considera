using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Considera.Api.Core.Interfaces;

namespace Considera.Api.Core.Models.MusiqueHub;

[Table("Music")]
public class Music : IEntity
{
    [Key, Column("ArtistId")]
    public Guid Id { get; set; }
    public Guid AlbumId { get; set; }
    public Guid SongId { get; set; }
    public Guid GenreId { get; set; }
    public Guid ArtistId => Id;
}