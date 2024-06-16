using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Interfaces.MusiqueHub.Services;
using ConsideraDevApi.Core.Models.MusiqueHub;
using Microsoft.AspNetCore.Mvc;

namespace ConsideraDev.Api.Controllers.Api.MusiqueHub;

[ApiController]
[Route("api/musique/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMusiqueHubService _musiqueHubService;

    public UserController(IMusiqueHubService musiqueHubService) => 
        _musiqueHubService = musiqueHubService;
    
    [HttpGet("getUsers")]
    public async Task<ActionResult<bool>> GetUsers()
    {
        return Ok(await _musiqueHubService.GetAllUsers());
    }

    [HttpGet("register")]
    public async Task<ActionResult<UserProtected>> Register(string username, string password)
    {
        Console.WriteLine("Registering user");
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return BadRequest("Username and password must be provided.");

        Console.WriteLine("Checking if user exists");
        if (await _musiqueHubService.HasUser(username))
            return BadRequest("Username already exists");
    
        Console.WriteLine("Adding user to database");
        return Ok(await _musiqueHubService.AddUser(username, password));
    }
    
    [HttpGet("login")]
    public async Task<ActionResult<UserProtected>> Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return BadRequest("Username and password must be provided.");

        return Ok(await _musiqueHubService.HasUser(username, password));
    }
}