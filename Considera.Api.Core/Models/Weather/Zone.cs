using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Considera.Api.Core.Models.Weather;

[Serializable]
public struct Zone : IFeature
{
    [JsonProperty("id")]
    public string UriId { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    public string? Geometry { get; set; }
    public ZoneProperties Properties { get; set; }
}

public interface IFeature
{
    [JsonProperty("type")]
    public string Type { get; set; }
    
    private ObjectType _objectType => 
        Enum.Parse<ObjectType>(Type, true);
}

[Serializable]
public struct Zones : IFeature
{
    [JsonProperty("type")]
    public string Type { get; set; }
    public Zone[] Features { get; set; }
    
    private ObjectType _objectType => 
        Enum.Parse<ObjectType>(Type, true);
}

public enum ObjectType
{
    FeatureCollection,
    Feature
}

[Serializable]
public struct ZoneProperties
{
    [JsonProperty("id")]
    public string ZoneId { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    public string Name { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    [JsonProperty("state")]
    public string StateCode { get; set; }
    [JsonProperty("forecastOffice")]
    public string ForecastOfficeUri { get; set; }
    public string GridIdentifier { get; set; }
    public string AwipsLocationIdentifier { get; set; }
    [JsonProperty("timeZone")]
    public string[] TimeZones { get; set; }
    public string[] Cwa { get; set; }
    public string[] ForecastOffices;
    public string[] ObservationsStations;
    public string? RadarStation { get; set; }
}