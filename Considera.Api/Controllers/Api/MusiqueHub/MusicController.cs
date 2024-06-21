using Considera.Api.Core.Interfaces.MusiqueHub.Services;
using Considera.Api.Core.Models;
using Considera.Api.Core.Models.MusiqueHub;
using Considera.Api.Core.Models.MusiqueHub.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Considera.Api.Controllers.Api.MusiqueHub;

[ApiController]
[Route("api/musique/music")]
public class MusicController : ControllerBase
{
    // Todo: Maybe
    // Controller => Service => Repository Input Validation => Repository
    // Repository => Repository Output Validation => Service => Controller
    
    private readonly IMusiqueHubService _musiqueHubService;
    private readonly IArtistService _artistService;
    private readonly IAlbumService _albumService;
    private readonly IGenreService _genreService;

    public MusicController(
        IMusiqueHubService musiqueHubService, 
        IArtistService artistService, 
        IAlbumService albumService, 
        IGenreService genreService)
    {
        _musiqueHubService = musiqueHubService;
        _artistService = artistService;
        _albumService = albumService;
        _genreService = genreService;
    }

    #region Artists
    [HttpGet("GetArtist")]
    public async Task<ActionResult<IEnumerable<Artist>>> GetArtist(string artistId) => 
        Ok(await _artistService.GetArtist(artistId));
    
    [HttpGet("GetArtists")]
    public async Task<ActionResult<IEnumerable<Artist>>> GetArtists() => 
        Ok(await _artistService.GetArtists());
    
    [HttpGet("GetArtistsByIds")]
    public async Task<ActionResult<IEnumerable<Artist>>> GetArtists(string artistIds) => 
        Ok(await _artistService.GetArtists(artistIds.Split(",")));
    #endregion
    
    #region Albums
    [HttpGet("GetAllAlbums")]
    public async Task<ActionResult<IEnumerable<Album>>> GetAllAlbums() => 
        Ok(await _albumService.GetAlbums());
    
    [HttpGet("GetAlbumsByIds")]
    public async Task<ActionResult<IEnumerable<Album>>> GetAlbums(string albumIds) => 
        Ok(await _albumService.GetAlbums(albumIds.Split(",")));
    
    [HttpGet("GetAlbumsByGenreId")]
    public async Task<ActionResult<Album>> GetAlbumsByGenreId(string genreId) => 
        Ok(await _albumService.GetAlbumsByGenreId(genreId));
    
    [HttpGet("GetAlbumsByGenreIds")]
    public async Task<ActionResult<IEnumerable<Album>>> GetAlbumsByGenreIds(string genreIds) => 
        Ok(await _albumService.GetAlbumsByGenreIds(genreIds.Split(",")));


    [HttpGet("GetAlbumsFromGenres")]
    public async Task<ActionResult<IEnumerable<Album>>> GetAlbumsFromGenres(string genreAlbumIds) => 
        Ok(await _albumService.GetAlbumsFromGenreAlbums(genreAlbumIds.Split(",")));

    #endregion

    #region Genres

    [HttpGet("GetAllGenres")]
    public async Task<ActionResult<IEnumerable<Genre>>> GetAllGenres(
        bool withAlbums = false, 
        bool withArtists = false) => 
        Ok(await _genreService.GetAllGenres(withAlbums, withArtists));

    [HttpGet("GetGenres")]
    public async Task<ActionResult<string>> GetAllGenres(string genreIds) => 
        Ok(await _genreService.GetGenres(genreIds.Split(",")));

    [HttpGet("GetGenreAlbumsFromGenres")]
    public async Task<ActionResult<IEnumerable<AlbumGenre>>> GetGenreAlbumsFromGenres(string genreIds) => 
        Ok(await _musiqueHubService.GetGenreAlbumsFromGenres(genreIds.Split(",")));

    [HttpGet("GetGenre")]
    public async Task<ActionResult<IEnumerable<Genre>>> GetGenre(Guid genreId) => 
        Ok(await _genreService.GetGenre(genreId));

    [HttpGet("ModifyGenre")]
    public async Task<ActionResult<IEnumerable<Genre>>> ModifyGenre(
        Guid genreId,
        string name,
        string desc) =>
        Ok(await _genreService.ModifyGenre(genreId, name, desc));

    [HttpGet("AssignSubgenres")]
    public async Task<ActionResult> AssignSubgenres(Guid authorId, string genres, string subgenres)
    {
        if (string.IsNullOrEmpty(genres) || string.IsNullOrEmpty(subgenres))
            return BadRequest("Genre and subgenres must be provided.");

        // like all of this logic should be done in a service. service methods can return a custom status object
        // failures returns a status object with a message and a status code
        // success returns a status object with a status code with the result object
        var genreEntity = await _genreService.GetGenre(genres);

        if (genreEntity == null)
            return BadRequest("Genre doesn't exist.");

        var subgenresList = subgenres.Split(",");
        
        await _genreService
            .AssignSubgenres(subgenresList.Select(x => new Genre
            {
                Name = Genre.GetValidName(x),
                ParentId = genreEntity.Id,
                AuthorId = authorId,
            }));
        
        return Ok();
    }
    #endregion

    #region Adders
    [HttpPost("AddArtist")]
    public async Task<ActionResult> AddArtist([FromBody] ArtistDto artist) => 
        await Add(
            artist, 
            _artistService, 
            "Artist has been added.", 
            "Artist name and bio must be provided.");
    
    [HttpPost("AddAlbum")]
    public async Task<ActionResult> AddAlbum([FromBody] AlbumDto album) => 
        await Add(
            album, 
            _albumService, 
            "Album has been added.", 
            "Album name and description must be provided.");

    // todo
    [HttpGet("AddGenres")]
    public async Task<ActionResult> AddGenres(Guid authorId, string genres)
    {
        if (genres.Length == 0)
            return BadRequest("No genres were provided.");
        
        await _genreService
            .AddGenres(genres.Split(",")
                .Select(x => new Genre
                {
                    Name = Genre.GetValidName(x)
                }));

        return Ok();
    }

    private async Task<ActionResult> Add<TDto>(
        TDto dto, 
        IService<TDto> service,
        string success, 
        string failure) where TDto : IDto
    {
        if (!dto.IsValid())
            return BadRequest(new ObjectLog<IDto>
            {
                Data = dto,
                Message = failure,
                Success = false
            });

        await service.Add(dto);

        return Ok(new ObjectLog<IDto>
        {
            Data = dto,
            Message = success,
            Success = true
        });
    }
    #endregion
}