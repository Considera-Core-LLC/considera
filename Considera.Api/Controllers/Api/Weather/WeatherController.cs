using Considera.Api.Core.Models.Weather;
using Considera.Api.Infrastructure.Services.Weather;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc;

namespace Considera.Api.Controllers.Api.Weather;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly ZoneService _zoneService;
    
    public WeatherController() => 
        _zoneService = new ZoneService();

    [HttpGet("GetZones")]
    public async Task<ActionResult<Zones>> GetZones() => 
        Ok(await _zoneService.GetZones());

    [HttpGet("GetZoneIds")]
    public async Task<ActionResult<IEnumerable<string>>> GetZoneIds() => 
        Ok(await _zoneService.GetZoneIds());
    
    [HttpGet("GetOfficeIds")]
    public async Task<ActionResult<IEnumerable<string>>> GetOfficeIds() => 
        Ok(await _zoneService.GetOfficeIds());

    public void test()
    {
        var service = new GoogleMaps.LocationServices.GoogleLocationService();
        service.ge
    }
    
    
    public async Task<ActionResult> GetRadar()
    {
        // Get Office Id:
        // - That has right StationId, and ZoneId
        
        return null;
    }

}