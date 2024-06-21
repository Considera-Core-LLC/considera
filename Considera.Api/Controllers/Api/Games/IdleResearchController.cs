using Considera.Api.Core.Interfaces.Games;
using Considera.Api.Core.Models.Games;
using Microsoft.AspNetCore.Mvc;

namespace Considera.Api.Controllers.Api.Games;

[ApiController]
[Route("api/[controller]")]
public class IdleResearchController : ControllerBase
{
    private readonly IGameService _gameService;

    public IdleResearchController(IGameService gameService) => 
        _gameService = gameService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IdleResearch>>> Get() => 
        Ok(await _gameService.GetIdleResearches());
}
