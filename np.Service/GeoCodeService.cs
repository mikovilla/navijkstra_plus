using np.Domain;
using np.Utility;

namespace np.Service
{
    public static class GeoCodeService
    {
        public async static Task<IEnumerable<GeoCodeProperty>> Call(string forwardAddress, string apiKey)
        {
            Thread.Sleep(1000);
            using HttpClient client = new HttpClient();
            string url = $"https://geocode.maps.co/search?q={forwardAddress}&api_key={apiKey}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return result.GetGeoCodeProperties();
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
            }
        }
    }
}
