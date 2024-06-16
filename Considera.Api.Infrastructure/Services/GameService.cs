using ConsideraDevApi.Core.Interfaces;
using ConsideraDevApi.Core.Interfaces.Games;
using ConsideraDevApi.Core.Models.Games;

namespace ConsideraDevApi.Infrastructure.Services;

public class GameService : IGameService
{
    private readonly IIdleResearchRepository _idleResearchRepository;

    public GameService(IIdleResearchRepository idleResearchRepository)
    {
        _idleResearchRepository = idleResearchRepository;
    }
    
    public async Task<IEnumerable<IdleResearch>> GetIdleResearches()
    {
        return await _idleResearchRepository.GetAll();
    }
}