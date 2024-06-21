using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Considera.Api.Core.Interfaces;

#pragma warning disable CS8618

namespace Considera.Api.Core.Models.MusiqueHub;

[Table("Genres")]
public class Genre : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? VerifierId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public List<Album> Albums { get; set; }
    public List<AlbumGenre> AlbumGenres { get; set; }

    public static string GetValidName(string name)
    {
        var split = name.Split(" ");
        for (var i = 0; i < split.Length; i++) 
            split[i] = $"{char.ToUpper(split[i][0])}{split[i][1..]}";
        return string.Join(" ", split);
    }
}
