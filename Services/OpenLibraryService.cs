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

    public async Task<BookInfoDto> GetBookInfoByTitleAsync(string title)
    {
        Console.WriteLine($"title in service sent to open library ${title}");
        var response = await _httpClient.GetStringAsync($"https://openlibrary.org/search.json?title={title}");
        var data = JObject.Parse(response);
        var firstBook = data["docs"]?.FirstOrDefault();

        if (firstBook == null)
        {
            return null;
        }

        var bookInfo = new BookInfoDto
        {
            Title = firstBook["title"].ToString(),
            Authors = firstBook["author_name"]?.ToObject<List<string>>(),
            Publishers = firstBook["publisher"]?.ToObject<List<string>>()?.Take(1).ToList(),
            FirstPublishYear = firstBook["first_publish_year"]?.ToObject<int>() ?? 0,
            ISBNs = firstBook["isbn"]?.ToObject<List<string>>()?.Take(1).ToList(),
            NumberOfPages = firstBook["number_of_pages_median"]?.ToObject<int>() ?? 0,
            CoverUrl = firstBook["cover_i"] != null ? $"https://covers.openlibrary.org/b/id/{firstBook["cover_i"]}-L.jpg" : null
        };

        return bookInfo;
    }
}
