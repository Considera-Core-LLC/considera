using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsideraDevApi.Core.Interfaces;
#pragma warning disable CS8618

namespace ConsideraDevApi.Core.Models.MusiqueHub;

[Table("AlbumGenre")]
public class AlbumGenre : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey(nameof(Album))]
    public Guid AlbumId { get; set; }

    [ForeignKey(nameof(Genre))]
    public Guid GenreId { get; set; }
        
}
