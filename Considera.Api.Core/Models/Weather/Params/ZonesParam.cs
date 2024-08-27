using System.Numerics;
using System.Text.Json.Serialization;
using Considera.Api.Core.Enums.Weather;
using Newtonsoft.Json;

namespace Considera.Api.Core.Models.Weather.Params;

public struct ZonesParam
{
    [JsonProperty("id")] 
    public string[]? ZoneIds { get; set; }
    
    [JsonProperty("area")]
    public string[]? AreaCodes { get; set; }
    
    [JsonProperty("region")]
    public string[]? RegionCodes { get; set; }
    
    [JsonProperty("type")]
    public string[]? ZoneTypes { get; set; }
    
    [JsonProperty("point")]
    public string? Point { get; set; }

    [JsonProperty("include_geometry")]
    public bool? IncludeGeometry { get; set; }
    
    [JsonProperty("limit")]
    public int? Limit { get; set; }
    
    [JsonProperty("effective")]
    public string? Effective { get; set; }
    
    private ZoneType? _zoneType => 
        ZoneTypes?.Length > 0
            ? Enum.Parse<ZoneType>(ZoneTypes[0], true) 
            : null;
    
    private Vector2? _pointVector => 
        Point != null && Point.Contains(',') 
            ? new Vector2(
                float.Parse(Point.Split(',')[0]), 
                float.Parse(Point.Split(',')[1])) 
            : null;
}