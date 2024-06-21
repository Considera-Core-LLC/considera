using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Considera.Api.Core.Interfaces;

#pragma warning disable CS8618

namespace Considera.Api.Core.Models.MusiqueHub;

[Table("AlbumArtist")]
public class AlbumArtist : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey(nameof(Album))]
    public Guid AlbumId { get; set; }

    [ForeignKey(nameof(Artist))]
    public Guid ArtistId { get; set; }
        
}
