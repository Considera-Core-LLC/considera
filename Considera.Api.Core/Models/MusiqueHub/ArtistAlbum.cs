using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Considera.Api.Core.Interfaces;

#pragma warning disable CS8618

namespace Considera.Api.Core.Models.MusiqueHub;

[Table("ArtistAlbum")]
public class ArtistAlbum : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey(nameof(Artist))]
    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; }

    [ForeignKey(nameof(Album))]
    public Guid AlbumId { get; set; }
    public Album Album { get; set; }
}
