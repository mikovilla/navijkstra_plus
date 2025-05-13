using Newtonsoft.Json;

namespace np.Domain
{
    public class GeoCodeProperty
    {
        [JsonProperty("place_id")]
        public int PlaceId { get; set; }
        [JsonProperty("licence")]
        public string License { get; set; }
        [JsonProperty("osm_type")]
        public string OpenStreetMapType { get; set; }
        [JsonProperty("osm_id")]
        public long OpenStreetMapId { get; set; }
        [JsonProperty("boundingbox")]
        public string[] BoundingBox { get; set; }
        [JsonProperty("lat")]
        public string Latitude { get; set; }
        [JsonProperty("lon")]
        public string Longitude { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("class")]
        public string Class { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("importance")]
        public float Importance { get; set; }
    }
}


