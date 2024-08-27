using Considera.Api.Core.Models.Weather;
using Newtonsoft.Json;

namespace Considera.Api.Infrastructure.Services.Weather;

public class ZoneService
{
    public int Test { get; set; }
    
    public async Task<Zones> GetZones()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://api.weather.gov/");
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
        var response = await client.GetAsync("zones");

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var zones = JsonConvert.DeserializeObject<Zones>(content);
            return zones;
        }
        return new Zones();
    }

    public async Task<IEnumerable<string>> GetZoneIds() => 
        (await GetZones()).Features
            .Select(x => x.Properties.ZoneId)
            .Distinct()
            .ToList();
    
    public async Task<IEnumerable<string>> GetOfficeIds() => 
        (await GetZones()).Features
            .Select(x => x.Properties.GridIdentifier) // do research
            .Distinct()
            .ToList();
}