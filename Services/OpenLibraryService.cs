using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class OpenLibraryService
{
    private readonly HttpClient _httpClient;

    public OpenLibraryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetBookInfoByTitleAsync(string title)
    {
        var response = await _httpClient.GetStringAsync($"https://openlibrary.org/search.json?title={title}");
        var data = JObject.Parse(response);
        var firstBook = data["docs"]?.FirstOrDefault();
        return firstBook?.ToString();
    }
}
