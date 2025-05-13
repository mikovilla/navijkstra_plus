using np.Domain;
using np.Utility;

namespace np.Service
{
    public static class OpenRouteService
    {
        public async static Task<OpenRouteServiceProperty> Call(string longlatStart, string longlatEnd, string apiKey)
        {
            Thread.Sleep(1000);
            using HttpClient client = new HttpClient();
            string url = $"https://api.openrouteservice.org/v2/directions/driving-car?api_key={apiKey}&start={longlatStart}&end={longlatEnd}";

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return result.GetOpenRouteServiceProperty();
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
            }
        }
    }
}
