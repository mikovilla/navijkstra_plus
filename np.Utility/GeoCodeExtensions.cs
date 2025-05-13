using Newtonsoft.Json;
using np.Domain;

namespace np.Utility
{
    public static class GeoCodeExtensions
    {
        public static IEnumerable<GeoCodeProperty> GetGeoCodeProperties(this string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<GeoCodeProperty>>(json) ?? Enumerable.Empty<GeoCodeProperty>();
        }
    }
}
