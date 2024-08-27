 using Considera.Api.Core.Enums.Weather;
using Newtonsoft.Json;

namespace Considera.Api.Core.Models.Weather.Params;

public struct ZoneForecastParam
{
    [JsonProperty("id")] 
    public string? ZoneId { get; set; }

    [JsonProperty("type")]
    public string[]? ZoneTypes { get; set; }
    
    private ZoneType[] _zoneTypes =>
        ZoneTypes?
            .Select(type => Enum.Parse<ZoneType>(type, true))
            .ToArray() ?? Array.Empty<ZoneType>();
}