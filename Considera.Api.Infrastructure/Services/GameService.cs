using Considera.Api.Core.Interfaces.Games;
using Considera.Api.Core.Models.Games;

namespace Considera.Api.Infrastructure.Services;

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