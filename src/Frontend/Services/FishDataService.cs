using System.Text.Json;
using Fishcard.Models;

namespace Fishcard.Frontend.Services
{
    public class FishDataService
    {
        private readonly HttpClient _httpClient;

        public FishDataService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<FishItem>> GetFishItemsAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(
                "sample-data/fishdata.json",
                cancellationToken);
            response.EnsureSuccessStatusCode();

            JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            FishItem[]? result = JsonSerializer.Deserialize<FishItem[]>(
                await response.Content.ReadAsStreamAsync(), options);

            if (result is null)
            {
                return Enumerable.Empty<FishItem>();
            }

            return result;
        }
    }
}