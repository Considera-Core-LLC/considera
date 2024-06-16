using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsideraDevApi.Core.Interfaces;

namespace ConsideraDevApi.Core.Models.MusiqueHub;

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
