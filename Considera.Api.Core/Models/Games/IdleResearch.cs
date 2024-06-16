using System.ComponentModel.DataAnnotations.Schema;
using ConsideraDevApi.Core.Interfaces;

namespace ConsideraDevApi.Core.Models.Games;

[Table("IdleResearch")]
public class IdleResearch : IEntity
{
    public Guid Id { get; set; }
    public double EnergyLog { get; set; }
}