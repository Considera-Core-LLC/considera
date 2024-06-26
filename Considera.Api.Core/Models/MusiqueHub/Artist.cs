﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Considera.Api.Core.Interfaces;

#pragma warning disable CS8618

namespace Considera.Api.Core.Models.MusiqueHub;

[Table("Artists")]
public class Artist : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? VerifierId { get; set; }
    public string Name { get; set; }
    public string? Bio { get; set; }
    public string Origin { get; set; }
    public DateTime FormedDate { get; set; }
    public List<Album> Albums { get; set; }
    public List<AlbumArtist> AlbumArtists { get; set; }
}