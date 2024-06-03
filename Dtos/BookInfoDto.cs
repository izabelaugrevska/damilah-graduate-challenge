public class BookInfoDto
{
    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public List<string> Publishers { get; set; }
    public int FirstPublishYear { get; set; }
    public List<string> ISBNs { get; set; }
    public int NumberOfPages { get; set; }
    public string CoverUrl { get; set; }
}