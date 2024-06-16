using ConsideraDevApi.Core.Models.Games;

namespace ConsideraDevApi.Core.Interfaces.Games;

public interface IGameService
{
    Task<IEnumerable<IdleResearch>> GetIdleResearches();
}