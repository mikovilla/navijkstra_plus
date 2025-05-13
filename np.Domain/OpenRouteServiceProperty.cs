using Newtonsoft.Json;

namespace np.Domain
{
    public class OpenRouteServiceProperty
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("bbox")]
        public float[] BoundingBox { get; set; }
        [JsonProperty("features")]
        public Feature[] Features { get; set; }
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("attribution")]
        public string Attribution { get; set; }
        [JsonProperty("service")]
        public string Service { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        [JsonProperty("query")]
        public Query Query { get; set; }
        [JsonProperty("engine")]
        public Engine Engine { get; set; }
    }

    public class Query
    {
        [JsonProperty("coordinates")]
        public float[][] Coordinates { get; set; }
        [JsonProperty("profile")]
        public string Profile { get; set; }
        [JsonProperty("profileName")]
        public string ProfileName { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
    }

    public class Engine
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("build_date")]
        public DateTime BuildDate { get; set; }
        [JsonProperty("graph_date")]
        public DateTime GraphDate { get; set; }
    }

    public class Feature
    {
        [JsonProperty("bbox")]
        public float[] BoundingBox { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }

    public class Properties
    {
        [JsonProperty("segments")]
        public Segment[] Segments { get; set; }
        [JsonProperty("way_points")]
        public int[] WayPoints { get; set; }
        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }

    public class Summary
    {
        [JsonProperty("distance")]
        public float Distance { get; set; }
        [JsonProperty("duration")]
        public float Duration { get; set; }
    }

    public class Segment
    {
        [JsonProperty("distance")]
        public float Distance { get; set; }
        [JsonProperty("duration")]
        public float Duration { get; set; }
        [JsonProperty("steps")]
        public Step[] Steps { get; set; }
    }

    public class Step
    {
        [JsonProperty("distance")]
        public float Distance { get; set; }
        [JsonProperty("duration")]
        public float Duration { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("instruction")]
        public string Instruction { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("way_points")]
        public int[] WayPoints { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("coordinates")]
        public double[][] Coordinates { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
