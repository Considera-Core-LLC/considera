using ConsideraDevApi.Core.Interfaces.Games;
using ConsideraDevApi.Core.Models.Games;
using Microsoft.AspNetCore.Mvc;

namespace ConsideraDev.Api.Controllers.Api.Games;

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
