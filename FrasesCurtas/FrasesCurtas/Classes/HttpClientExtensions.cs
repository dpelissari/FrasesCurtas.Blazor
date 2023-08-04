using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrasesCurtas.Classes
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
