using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Considera.Api.Core.Models.Weather.Params;

public struct ZoneObservationsParam
{
    [JsonProperty("id")] 
    public string? ZoneId { get; set; }
    
    [JsonProperty("start")] 
    public DateTime Start { get; set; }
    
    [JsonProperty("end")]
    public DateTime End { get; set; }
    
    [JsonProperty("limit")]
    public int? Limit { get; set; }
}