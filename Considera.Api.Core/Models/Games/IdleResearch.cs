using System.ComponentModel.DataAnnotations.Schema;
using Considera.Api.Core.Interfaces;

namespace Considera.Api.Core.Models.Games;

[Table("IdleResearch")]
public class IdleResearch : IEntity
{
    public Guid Id { get; set; }
    public double EnergyLog { get; set; }
}