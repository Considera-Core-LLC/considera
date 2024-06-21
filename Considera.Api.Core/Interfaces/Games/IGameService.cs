using Considera.Api.Core.Models.Games;

namespace Considera.Api.Core.Interfaces.Games;

public interface IGameService
{
    Task<IEnumerable<IdleResearch>> GetIdleResearches();
}