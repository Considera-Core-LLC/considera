using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Considera.Api.Core.Interfaces;

namespace Considera.Api.Core.Models.MusiqueHub;

[Table("Songs")]
public class Song : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid AlbumId { get; set; }
    public string Name { get; set; }
    public int Length { get; set; }
    
    public Song() => Name = "";
}
